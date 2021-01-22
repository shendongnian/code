      static void Main(string[] args)
            {
                List<object> ll = new List<object>() { 1, 2, "abcd", "xyz", 22.3, 900, "junk" };
                ll.RemAll(typeof(int));
                ll.ForEach(x => Console.WriteLine(x));
            }
