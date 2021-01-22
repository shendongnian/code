    int i = (int) stringData;
    watch.Elapsed = {00:00:00.1732388}
    watch2.Elapsed= {00:00:00.0878196}
     // Mesary start
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int f = 1; f < 1000000; f++)
                    {
                        item.Count = FastInt32.IntParseFast(dt.Rows[i]["TopCount"]);
                    }   // Execute the task to be timed
                    watch.Stop();
                    Console.WriteLine("Elapsed: {0}", watch.Elapsed);
                    Console.WriteLine("In milliseconds: {0}", watch.ElapsedMilliseconds);
                    Console.WriteLine("In timer ticks: {0}", watch.ElapsedTicks);
                    // Mesary end
                    // Mesary start
                    Stopwatch watch2 = new Stopwatch();
                    watch2.Start();
                    for (int n = 1; n < 1000000; n++)
                    {
                        item.Count = (int)(dt.Rows[i]["TopCount"]);
                    }   // Execute the task to be timed
                    watch2.Stop();
                    Console.WriteLine("Elapsed: {0}", watch2.Elapsed);
                    Console.WriteLine("In milliseconds: {0}", watch2.ElapsedMilliseconds);
                    Console.WriteLine("In timer ticks: {0}", watch2.ElapsedTicks);
                    // Mesary end
