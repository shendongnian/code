    static void Write<T>(Stream stream, T[] buffer) where T : struct
    {
        System.Runtime.InteropServices.GCHandle handle = System.Runtime.InteropServices.GCHandle.Alloc(buffer, System.Runtime.InteropServices.GCHandleType.Pinned);
        IntPtr address = handle.AddrOfPinnedObject();
        int byteCount = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)) * buffer.Length;
        byte[] bytes = new byte[byteCount];
        System.Runtime.InteropServices.Marshal.Copy(address, bytes, 0, byteCount);
        stream.Write(bytes, 0, bytes.Length);
        handle.Free();
    }   
    [STAThread]
    static void Main(string[] args)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        int[] ints = new int[] { 1, 2, 3, 4, 5 };
        Write(ms, ints);
    }
