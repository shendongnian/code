        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch(); 
            Console.WriteLine("Linq method");
            stopWatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                LinqMethod(); 
            }
            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
            stopWatch.Reset();
            Console.WriteLine("Loop method");
            stopWatch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                LoopMethod();
            }
            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
            Console.ReadLine();
        }
        private static void LinqMethod()
        {
            int[] numbers = new int[] { 13, 22, -5, 94, 66, -38, 41, -79, -1, 53 };
            int[] firstminus = new int[1];
            firstminus[0] = numbers.FirstOrDefault(n => n < 0);
        }
        private static void LoopMethod()
        {
            int[] numbers = new int[] { 13, 22, -5, 94, 66, -38, 41, -79, -1, 53 };
            int[] firstminus = new int[1];
            for (int i = 0; i < 10; i++)
            {
                if (numbers[i] < 0)
                {
                    firstminus[0] = numbers[i];
                    break; 
                }
            }
        }
