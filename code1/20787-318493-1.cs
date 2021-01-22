        static void Main(string[] args)
        {
            IEnumerable<int> list = new List<int>() { -5, 3, -2, 1, 2, -7 };
            IEnumerable<bool> isNegativeList = list.Select<int, bool>(i => i > 0);
            foreach (bool isNegative in isNegativeList)
            {
                Console.WriteLine(isNegative);
            }
            Console.ReadKey();        
        }
       
