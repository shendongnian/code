    for (int j = 0; j < 10; j++)
    {
        Stopwatch w = new Stopwatch();
        double d = 0;
        w.Start();
        for (int i = 0; i < 10000000; i++)
        {
            try
            {
                d = Math.Sin(d);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                d = Math.Sin(d);
            }
        }
        w.Stop();
        Console.Write("   try/catch/finally: ");
        Console.WriteLine(w.ElapsedMilliseconds);
        w.Reset();
        d = 0;
        w.Start();
        for (int i = 0; i < 10000000; i++)
        {
            d = Math.Sin(d);
            d = Math.Sin(d);
        }
        w.Stop();
        Console.Write("No try/catch/finally: ");
        Console.WriteLine(w.ElapsedMilliseconds);
        Console.WriteLine();
    }
