        public static void Test1()
        {
            List<int> a = new List<int>() { 1, 2, 3 };
            List<int> b = new List<int>() { 3, 2, 1 };
            List<int> c = CombineLists.Combine(i => i, a, b);
            c.ForEach(i => Console.WriteLine(i));
        }
