    watch = Stopwatch.StartNew();
    fixed (byte* p = buffer)
    {
        for (int i = 0; i < LOOP; i++)
        {
            *((int*)(p + INDEX)) = VALUE;
        }
    }
    watch.Stop();
    Console.WriteLine("Set6: " + watch.ElapsedMilliseconds + "ms");
