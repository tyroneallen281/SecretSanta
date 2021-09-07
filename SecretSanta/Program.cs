using CM.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta
{
    public class Program
    {
        public static List<Person> listNames;
         public static void Main(string[] args)
        {
            Console.WriteLine("Secret Santa!");
            listNames = new List<Person> ();
            listNames.Add(new Person( "Tyrone", "+27829698942",1));
            listNames.Add(new Person("Megan", "+27828300281",1));
            listNames.Add(new Person("Judy", "+27794999517", 2));
            listNames.Add(new Person("Stewart", "+27796965927", 2));
            listNames.Add(new Person("Cheryl", "+27722456860", 3));
            listNames.Add(new Person("Heinrich", "+27761407017", 3));
            listNames.Add(new Person("Bianca Allen", "+27828833061", 4));
            listNames.Add(new Person("David Jr Allen", "+27828833061", 4));
            listNames.Add(new Person("Lexia", "+27824678323", 5));
            listNames.Add(new Person("Diego", "+27824678323", 5));
            listNames.Add(new Person("Lisa", "+27835636362", 4));
            listNames.Add(new Person("Aunt Marion", "+27794999517", 6));
            listNames.Add(new Person("Mrs Roos", "+27794999517", 7));
            listNames.Add(new Person("Jake", "+27795259651", 8));
            listNames.Add(new Person("Bianca Van Heerden", "+27795259651", 8));
            listNames.Add(new Person("Johan Van Heerden", "+27636241139", 8));
            listNames.Add(new Person("Paula Hofmeyr", "+27828215378", 8));
            listNames.Add(new Person("David (Sr)", "+27822101949", 9));
            listNames.Add(new Person("Shirley", "+27823192073", 9));
            listNames.Add(new Person("Jaime", "+27827184507", 5));
            listNames.Add(new Person("Christy", "+27824678323", 5));
            listNames.Add(new Person("George", "+27828833061", 4));
            listNames.Add(new Person("Manfred", "+27824552277", 10));
            listNames.Add(new Person("Anne", "+27727113641", 10));
            listNames.Add(new Person("Ouma Helena", "+27722458307", 2));
            listNames.Add(new Person("Mariske", "+27826374640", 11));
            listNames.Add(new Person("Albert", "+27823808260", 11));
            var tries = 0;
            for (tries = 0; tries < 100; tries++)
            {
                listNames = listNames.OrderBy(a => Guid.NewGuid()).ToList();
                var works = true;
                for (int j = 0; j < listNames.Count()-2; j++)
                {
                    if(listNames[j].Group == listNames[j + 1].Group)
                    {
                        works = false;
                    }
                }
                if (listNames[0].Group == listNames[listNames.Count()-1].Group)
                {
                    works = false;
                }
                if (works)
                {
                    break;
                }
            }
            var logFile = System.IO.File.Create("D:\\secretSanta.txt");
            var logWriter = new System.IO.StreamWriter(logFile);
            
           
            for (int j = 0; j < listNames.Count() - 1; j++)
            {
                var messsage = $"HELLO this is SANTA!! {listNames[j].Name} needs to buy a gift for {listNames[j+1].Name}. Please keep this a SECRET!!! See you all Dec 8th. LOVE SANTA";
                logWriter.WriteLine(messsage);
                sendSMS(listNames[j].Number, messsage);
            }
           
            var messsage2 = $"HELLO this is SANTA!! {listNames[listNames.Count() - 1].Name} needs to buy a gift for {listNames[0].Name}.  Please keep this a SECRET!!! See you all Dec 8th. LOVE SANTA";
            logWriter.WriteLine(messsage2);
            sendSMS(listNames[listNames.Count() - 1].Number, messsage2);
            logWriter.Dispose();
            Console.ReadLine();


        }

        private static void sendSMS(string number, string message)
        {
            var smsClient = new TextClient(new Guid("A5CECE56-2EF5-42D2-8754-DD2C6693536B"));
            try
            {
                var result1 = Task.Run(() => smsClient.SendMessageAsync(message, "SANTA", new List<string> { number }, $"{number}")).Result;
            }
            catch (Exception)
            {
              
            }
        }
    }

    

    public  class Person{
        public Person(string name,string number,int group)
        {
            Name = name;
            Number = number;
            Group = group;
        }
        public string Number { get; set; }
        public string Name { get; set; }
        public int Group { get; set; }
    }
}
