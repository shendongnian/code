    unsafe static void Write<T>(Stream stream, T[] buffer) where T : struct
    {
        System.Runtime.InteropServices.GCHandle handle = System.Runtime.InteropServices.GCHandle.Alloc(buffer, System.Runtime.InteropServices.GCHandleType.Pinned);
        IntPtr address = handle.AddrOfPinnedObject();
        int byteCount = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)) * buffer.Length;
        byte* ptr = (byte*)address.ToPointer();
        byte* endPtr = ptr + byteCount;
        while (ptr != endPtr)
        {
            stream.WriteByte(*ptr++);
        }
        handle.Free();
    }
