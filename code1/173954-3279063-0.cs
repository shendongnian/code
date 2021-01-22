    class Program
    {
        static void Main(string[] args)
        {
            List<MyObject> list = new List<MyObject>();
    
            list.Add(new MyObject() { Age = 12, Name = "ABC" });
            list.Add(new MyObject() { Age = 11, Name = "ABC" });
            list.Add(new MyObject() { Age = 14, Name = "BBC" });
    
            var sorted = list.OrderBy(mo => mo.Name).ThenBy(mo => mo.Age);
    
            foreach (var myObject in sorted)
            {
                Console.WriteLine(string.Format("{0} - {1}",
                                  myObject.Name, myObject.Age));
            }
        }
    }
