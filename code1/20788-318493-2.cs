        static void Main(string[] args)
        {
            IEnumerable<int> list = new List<int>() { -5, 3, -2, 1, 2, -7 };
            IEnumerable<bool> isPositiveList = list.Select<int, bool>(i => i > 0);
            foreach (bool isPositive in isPositiveList)
            {
                Console.WriteLine(isPositive);
            }
            Console.ReadKey();        
        }
       
