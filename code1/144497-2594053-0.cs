    class Program
    {
        const int TestIterations = 5000000;
        static void Main(string[] args)
        {
            RunTest("Byte Loop", TestByteLoop, TestIterations);
            RunTest("Short Loop", TestShortLoop, TestIterations);
            RunTest("Int Loop", TestIntLoop, TestIterations);
            Console.ReadLine();
        }
        static void RunTest(string testName, Action action, int iterations)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine("{0}: Elapsed Time = {1}", testName, sw.Elapsed);
        }
        static void TestByteLoop()
        {
            int x = 0;
            for (byte b = 0; b < 255; b++)
            {
                ++x;
            }
        }
        static void TestShortLoop()
        {
            int x = 0;
            for (short s = 0; s < 255; s++)
            {
                ++x;
            }
        }
        static void TestIntLoop()
        {
            int x = 0;
            for (int i = 0; i < 255; i++)
            {
                ++x;
            }
        }
    }
