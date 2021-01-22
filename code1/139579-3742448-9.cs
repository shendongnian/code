    public void Test()
    {
        int pans = 0;
        var sw = new Stopwatch();
        sw.Start();
        for (int count = 0; count < 100; count++)
        {
            pans = 0;
            for (int i = 123456789; i <= 123987654; i++)
            {
                if (IsPandigital(i))
                {
                    pans++;
                }
            }
        }
        sw.Stop();
        Console.WriteLine("{0}pcs, {1}ms", pans, sw.ElapsedMilliseconds / 100m);
    }
