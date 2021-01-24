    public class Person
        {
            public int PersonID { get; set; }
        }
        public static void Test()
        {
            var persons = new List<Person>()
            {
                new Person() {PersonID=1 },
                new Person() {PersonID=2 },
            };
            var nextId = GetNextId(persons, i => i.PersonID);//returns 3
        }
 
