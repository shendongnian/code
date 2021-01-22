    public static unsafe void WriteValues()
    {
        UnmanagedStruct s;
        GetUnmanagedStruct(out s);
        for (var i = 0; i < s.size; i++)
        {
            for (ushort* p = s.shortValues[i]; p != null; p++)
            {
                ushort x = *p;
                Console.WriteLine(x);
            }
        }
    }
