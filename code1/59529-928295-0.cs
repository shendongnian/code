    class Program
    {
        class MyArgs { }
        class Razzie
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Razzie MyMethod(MyArgs args)
            {
                //do whatever you want here and return a Razzie (maybe "this" even)
                return new Razzie { FirstName = FirstName.ToUpper() };
            }
        }
        static void Main(string[] args)
        {
            var bloops = new List<Razzie>
                {
                    new Razzie{FirstName = "name"},
                    new Razzie{FirstName = "nAmE"}
                };
            var myArgs = new MyArgs();
            var results = from item in bloops
                          select new Razzie
                          {
                              FirstName = item.FirstName,
                              LastName = item.LastName
                          }.MyMethod(myArgs);
            foreach (var r in results)
                Console.WriteLine(r.FirstName);
            Console.ReadKey();
        }
    }
