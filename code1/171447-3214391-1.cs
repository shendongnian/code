    class Program
    {
        private static int _last = 0;
        private static IEnumerable<int> GetValues()
        {
            while (true)
                yield return _last++;
        }
        static void Main(string[] args)
        {
            for (var i = 0; i < 3; i++)
                foreach (var value in GetValues().Skip(5 * i).Take(5))
                    Console.Write(value + ",");
            // 0,1,2,3,4,10,11,12,13,14,25,26,27,28,29,
            Console.WriteLine();
            _last = 0;
            foreach (var page in GetValues().AsPages(5).Take(3))
                foreach (var value in page)
                    Console.Write(value + ",");
            // 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,
        }
    }
