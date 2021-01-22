        static void Main(string[] args)
        {
            Stopwatch masterSW;
            Stopwatch sw=null;
            int count;
            for (int i = 0; i < 10; i++)
            {
                count = 0;
                masterSW = Stopwatch.StartNew();
                while (true)
                {
                    if (sw == null || !sw.IsRunning)
                        sw = Stopwatch.StartNew();
                    if (sw.Elapsed.Ticks >= 6510)
                    {
                        count++;
                        sw.Stop();
                        if (masterSW.Elapsed.Ticks  >= 10000000)
                            break;
                    }
                }
                Debug.WriteLine(count.ToString());
            }
        }
