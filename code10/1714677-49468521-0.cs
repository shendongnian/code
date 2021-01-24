          static void Main(string[] args)
          {
            Test t = new Test();
            t.Name = "bob";
            t.Address = "CT";
            List<Test> lst = new List<Test>();
            lst.Add(t);
            lst.ForEach(show);
        }
        private static void show(Test obj)
        {
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Address);
        }
