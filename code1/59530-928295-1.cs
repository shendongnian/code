    class MyArgs { }
    class Razzie //pretend this is a 3rd party class that we can't edit
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    static class RazzieExtensions
    {
        public static Razzie MyMethod(this Razzie razzie, MyArgs args)
        {
            razzie.FirstName = razzie.FirstName.ToUpper();
            return razzie;
        }
    }
    class Program
    {
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
