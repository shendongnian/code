    [DllImport("msvcrt.dll", 
    EntryPoint = "memset", 
    CallingConvention = CallingConvention.Cdecl, 
    SetLastError = false)]
    public static extern IntPtr MemSet(IntPtr dest, int c, int count);
    static void Main(string[] args)
    {
        byte[] arr = new byte[3];
        GCHandle gch = GCHandle.Alloc(arr, GCHandleType.Pinned);
        MemSet(gch.AddrOfPinnedObject(), 0x7, arr.Length); 
    }
