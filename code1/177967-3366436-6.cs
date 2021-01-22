    public IntPtr ManagedAllocMemory(long nBytes)
    {
        byte[] data = new byte[nBytes];
        GCHandle dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        unsafe {
            fixed (byte *b = &data[0]) {
                dataPtr = new IntPtr(b);
                RegisterPointerHandleAndArray(dataPtr, dataHandle, data);
                return dataPtr;
            }
        }
    }
