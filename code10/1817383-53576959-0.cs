    stopwatch = System.Diagnostics.Stopwatch.StartNew();
    uint count = 0;
    int query = (int)Convert.ToByte('\n');
    using (var stream = File.OpenRead(filepath))
    {
        int current;
        do
        {
            current = stream.ReadByte();
            if (current == query)
            {
                count++;
                continue;
            }
        } while (current!= -1);
    }
    Console.WriteLine($"Using ReadByte,Time : {stopwatch.Elapsed.TotalMilliseconds},Count: {r}");
