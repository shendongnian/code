        static void Main()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int div = 2;
            foreach (var item in list.Where(x => x % div == 0))
            {
                Console.WriteLine(item);
            }
            ListSearcher ls = new ListSearcher();
            ls.div = 2;
            foreach (var item in list.Where(ls.Test))
            {
                Console.WriteLine(item);
            }
        }
        class ListSearcher
        {
            public int div;
            public bool Test(int x)
            {
                return x % div == 0;
            }
        }
