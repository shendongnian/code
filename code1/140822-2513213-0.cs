        public static IEnumerable<int> Square(IEnumerable<int> nums)
        {
            var list = nums.ToList();
            Console.WriteLine("Nums in Square: {0}", list.Count);
            foreach (int num in list)
            {
                Console.WriteLine("Square: {0}", num);
                yield return num * num;
                Console.WriteLine("After Square yield: {0}", num);
            }
        }
