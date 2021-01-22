    static public void Main(string[] args)
    {
        Stopwatch w = new Stopwatch();
        double d = 0;
        w.Start();
        for (int i = 0; i < 10000000; i++)
        {
            try
            {
                d = Math.Sin(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        w.Stop();
        Console.WriteLine(w.Elapsed);
        w.Reset();
        w.Start();
        for (int i = 0; i < 10000000; i++)
        {
            d = Math.Sin(1);
        }
        w.Stop();
        Console.WriteLine(w.Elapsed);
    }
