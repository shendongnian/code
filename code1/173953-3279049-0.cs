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
            var sortedList = from element in list
                             orderby element.Name
                             orderby element.Age
                             select element;
    
            foreach (var item in sortedList)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Age);
            }
        }
    }
