        public class Person
        {
            public string State { get; set; }
            public int Age { get; set; }
        }
        public static Main()
        {
            var persons = new List<Person>
            {
               new Person { State = "CA", Age = 20 },
               new Person { State = "CA", Age = 20 },
               new Person { State = "CA", Age = 30 },
               new Person { State = "WA", Age = 60 },
               new Person { State = "WA", Age = 70 },
            };
            var result = persons
                .GroupBy("State", "it")
                .Select(@"new ( 
                   it.Key,
                   it.Count() as Count,
                   it.GroupBy(Age)
                     .Select(new (it.Key, it.Count() as Count))
                     .ToList() as Items
                )");
             foreach (dynamic group in result)
             {
                 Console.WriteLine($"Group.Key: {group.Key}");
                 foreach (dynamic subGroup in group.Items)
                 {
                     Console.WriteLine($"SubGroup.Key: {subGroup.Key}");
                     Console.WriteLine($"SubGroup.Count: {subGroup.Count}");
                 }
             }
        }
 
