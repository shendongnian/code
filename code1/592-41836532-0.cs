    public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
    {
        var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        try {
            return (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        }
        finally {
            handle.Free();
        }
    }
