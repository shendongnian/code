    class Program
        {
            static void Main(string[] args)
            {
                List<Person> persons= new List<Person>();
                var result = from p in persons
                select new
                 {
                  Name = (s.IsMarried ? s.X : s.Y)
                 };
            }
        }
        class Person
        {
            public bool IsMarried { get; set; }
            public string X { get; set; }
            public string Y { get; set; }
        }
