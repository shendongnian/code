                System.Diagnostics.Stopwatch time = new Stopwatch();
                string test = string.Empty;
                time.Start();
                for (int i = 0; i < 100000; i++)
                {
                    test += i;
                }
                time.Stop();
                System.Console.WriteLine("Using String-> " + time.ElapsedMilliseconds + " Milliseconds");
                //Result:   Using String-> 15423 Milliseconds
                System.Console.WriteLine(); 
                StringBuilder test1 = new StringBuilder();
                time.Reset();
                time.Start();
                for (int i = 0; i < 100000; i++)
                {
                    test1.Append(i);
                }
                time.Stop();
                System.Console.WriteLine("Using StringBuilder -> " + time.ElapsedMilliseconds + " Milliseconds");
                //Result:   Using String-> 10 Milliseconds
 
