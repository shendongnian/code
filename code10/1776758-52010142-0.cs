    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MyPacket
    {
        public Byte Address;        // Byte 0
        public Byte FunctionCode;   // Byte 1
        public Byte ByteField;      // Byte 2
        public UInt32 UInt32Field;  // Bytes 3-6
        public UInt64 UInt64Field;  // Byte 7-14
        public UInt16 ErrorCode;    // Bytes 15-16
    }
    
    public static bool TryParse<T>(byte[] array, out T packet) where T : struct
    {
        try
        {
            var size = Marshal.SizeOf(typeof(T));
            var p = Marshal.AllocHGlobal(size);
            Marshal.Copy(array, 0, p, size);
            packet = (T)Marshal.PtrToStructure(p, typeof(T));
            Marshal.FreeHGlobal(p);
            return true;
        }
        catch
        {
            packet = default(T);
            return false;
        }
    }
    
    static int Main(string[] args)
    {
        // Create a sample frame
        byte[] bytes = new byte[] { 0x0, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
    
        MyPacket packet;
    
        if (TryParse<MyPacket>(bytes, out packet))
        {
            // Process packet here...
        }
        return 0;
    }
