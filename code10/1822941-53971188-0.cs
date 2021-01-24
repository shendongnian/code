    public static int InitOptions(ref Options options)
    {
        if (IntPtr.Size == 4)
            return InitOptions32(ref options);
        Options64 o64 = options;
        var i = InitOptions64(ref o64);
        options = o64;
        return i;
    }
    [DllImport("my64.dll", EntryPoint = "InitOptions")]
    private static extern int InitOptions64(ref Options64 options);
    [DllImport("my32.dll", EntryPoint = "InitOptions")]
    private static extern int InitOptions32(ref Options options);
    [StructLayout(LayoutKind.Sequential)]
    public struct Options
    {
        public Flags flags;
        public uint a;
        public uint b;
        public uint c;
        public static implicit operator Options64(Options value) => new Options64 { flags = value.flags, a = value.a, b = value.b, c = value.c };
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Options64
    {
        public Flags flags;
        public ulong a;
        public ulong b;
        public ulong c;
        public static implicit operator Options(Options64 value) => new Options { flags = value.flags, a = (uint)value.a, b = (uint)value.b, c = (uint)value.c };
    }
