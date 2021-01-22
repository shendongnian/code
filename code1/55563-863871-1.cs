    // NOTE: runnable - copy in paste into your own project
    class Program
        {
            static int endVal = 32768;
            static int runCount = 100;
            static void Main(string[] args)
            {
                Stopwatch doublesw = Stopwatch.StartNew();
                for (int i = 0; i < runCount; ++i)
                    doubleTest();
                doublesw.Stop();
                Console.WriteLine("Double: " + doublesw.ElapsedMilliseconds);
                Stopwatch floatsw = Stopwatch.StartNew();
                for (int i = 0; i < runCount; ++i)
                    floatTest();
                floatsw.Stop();
                Console.WriteLine("Float: " + floatsw.ElapsedMilliseconds);
                Console.ReadLine();
            }
    
            static void doubleTest()
            {
                double value = 0;
                double incr = 0.001D;
    
                while (value < endVal)
                {
                    value += incr;
                }
            }
    
            static void floatTest()
            {
                float value = 0;
                float incr = 0.001f;
    
                while (value < endVal)
                {
                    value += incr;
                }
            }
        }
    }
