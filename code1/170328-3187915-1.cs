        public void TypeTest()
        {
            IEnumerable<int> a = Enumerable.Empty<int>();
            IEnumerable<int> b = a.ToList();
            IEnumerable<int> c = b.Where(x => x%2 == 1);
            Console.WriteLine(a.GetType().Name);
            Console.WriteLine(b.GetType().Name);
            Console.WriteLine(c.GetType().Name);
        }
