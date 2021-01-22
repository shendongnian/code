        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evens = Where(numbers, IsEven);
            foreach (int even in evens)
            {
                Console.WriteLine(even);
            }
        }
