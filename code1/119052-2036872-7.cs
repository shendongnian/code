    if (!BitConverter.IsLittleEndian)
    {
        throw new NotSupportedException();
    }
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
    watch = Stopwatch.StartNew();
    fixed (byte* p = buffer)
    {
        for (int i = 0; i < LOOP; i++)
        {
            *((int*)(p + INDEX)) = System.Net.IPAddress.HostToNetworkOrder(VALUE);
        }
    }
    watch.Stop();
    Console.WriteLine("Set7: " + watch.ElapsedMilliseconds + "ms");
