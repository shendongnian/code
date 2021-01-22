            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (int i = 0; i < 5000000; i++)
            {
                int MSNow = DateTime.Now.Millisecond * 1000;
                if (MSNow.ToString().Length > 2)
                {
                    int ms = Convert.ToInt32(
                        Convert.ToString(MSNow).Substring(0, 3));
                }
            }
            stop.Stop();
            Console.WriteLine(stop.ElapsedMilliseconds);
            stop = new Stopwatch();
            stop.Start();
            for (int i = 0; i < 5000000; i++)
            {
                int MSNow = DateTime.Now.Millisecond * 1000;
                int lengthMS = MSNow.ToString().Length;
                if (lengthMS > 2)
                {
                    double Length = Math.Pow(10, (lengthMS - 3));
                    double Truncate = Math.Truncate((double)MSNow / Length);
                }
            }
            stop.Stop();
            Console.Write(stop.ElapsedMilliseconds);
            Console.ReadKey();
