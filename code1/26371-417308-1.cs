    static class Program
    {
        public class Person
        {
            public string Key { get; set; }
            public Person(string key)
            {
               Key = key;
            }
        }
        public class NotPerson
        {
            public string Key { get; set; }
            public NotPerson(string key)
            {
               Key = key;
            }
        }
        static void Main()
        {
                
           List<Person> persons = new List<Person>()
           { 
               new Person ("1"),
               new Person ("2"),
               new Person ("3"),
               new Person ("4")
           };
                
           List<NotPerson> notpersons = new List<NotPerson>()
           { 
               new NotPerson ("3"),
               new NotPerson ("4")
           };
                
           var filteredResults = from n in persons
                                 where !notpersons.Any(y => n.Key == y.Key)
                                 select n;
                
           foreach (var item in filteredResults)
           {
              Console.WriteLine(item.Key);
           }
        }
     }
