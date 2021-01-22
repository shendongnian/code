    class Program
        {
            static void Main(string[] args)
            {
                List<Person> persons= new List<Person>();
                var result = from p in persons
                select new
                 {
                  Name = (s.IsMarried ? s.Name : s.LNAme)
                 };
            }
        }
        class Person
        {
            public bool IsMarried { get; set; }
            public string Name { get; set; }
            public string LNAme { get; set; }
        }
