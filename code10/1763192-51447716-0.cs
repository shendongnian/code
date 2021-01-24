    [DllImport("Kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
                private static extern void CopyMemory_Win32(IntPtr dest, IntPtr src, uint size);
                
    [DllImport("Kernel32.dll", EntryPoint = "RtlCopyMemory", SetLastError = false)]
                private static extern void CopyMemory_Win64(IntPtr dest, IntPtr src, uint size);
    
        float[] Data=new float[memsize]
        var hnd = GCHandle.Alloc(obj, GCHandleType.Pinned);
        IntPtr ptr = hnd.AddrOfPinnedObject();
    //Get Size in bytes a float is 4 bytes long.
        CopyMemory_Win64(memHandle,ptr,memsize*4);
        hnd.Free();
