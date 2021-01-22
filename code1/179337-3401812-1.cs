        static void Main(string[] args)
        {
            Stopwatch masterSW;
            Stopwatch sw=null;
            int count;
            sw = Stopwatch.StartNew();
            sw.Reset();
            for (int i = 0; i < 10; i++)
            {
                count = 0;
                masterSW = Stopwatch.StartNew();
                while (count!=1536) //1537*651 microsecond is about a second (1.0005870 second)
                {
                    if (!sw.IsRunning)
                        sw.Start();
                    if (sw.Elapsed.Ticks >= 6510)
                    {
                        count++;
                        sw.Reset();
                    }
                }
                Debug.WriteLine("Ticks: " + masterSW.Elapsed.Ticks.ToString());
            }
        }
