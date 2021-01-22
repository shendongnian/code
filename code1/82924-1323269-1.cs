    public unsafe struct UnmanagedStruct
    {
        public short size;
        public ushort** shortValues;
    }
    [DllImport("example.dll")]
    public static unsafe extern void GetUnmanagedStruct(out UnmanagedStruct s);
    public static unsafe void WriteValues(UnmanagedStruct* s)
    {
        for (var i = 0; i < s->size; i++)
        {
            ushort x = (*s->shortValues)[i];
            Console.WriteLine(x);
        }
    }
