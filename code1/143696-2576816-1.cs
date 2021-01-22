        public readonly static int SIZE = 100000;
        static void Main()
        {
            int[] nums = new int[SIZE];
            BuildArray(nums);
            Stopwatch stopwatch = new Stopwatch();
            long duration = 0;
            stopwatch.Start();
            DisplayNums(nums);
            stopwatch.Stop();
            duration = stopwatch.ElapsedMilliseconds/1000;
            Console.WriteLine("Time: " + duration);
            Console.ReadKey();
        }
        static void BuildArray(int[] arr)
        {
            for (int i = 0; i < SIZE; i++)
                arr[i] = i;
        }
        static void DisplayNums(int[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                Console.WriteLine(arr[i]);
        }
