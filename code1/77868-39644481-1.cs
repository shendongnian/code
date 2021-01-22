    public static bool GenerateBoolean()
    {
        var gen1 = 0;
        var gen2 = 0;
        var task = Task.Run(() =>
        {
            while (gen1 < 1 || gen2 < 1)
                Interlocked.Increment(ref gen1);
        });
        while (gen1 < 1 || gen2 < 1)
            Interlocked.Increment(ref gen2);
        return (gen1 + gen2) % 2 == 0;
    }
