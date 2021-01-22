    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MyObject>(new[]
            {
                new MyObject { Name = "ABC", Age = 12 },
                new MyObject { Name = "BBC", Age = 14 },
                new MyObject { Name = "ABC", Age = 11 },
            });
            var sortedList = list.OrderBy( x => new { x.Name , x.Age });
    
            foreach (var item in sortedList)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Age);
            }
        }
    }
