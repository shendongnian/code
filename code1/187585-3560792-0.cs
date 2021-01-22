    var handles = new GCHandle[arrays.Count];
    byte*[] pointers = new byte*[arrays.Count];
    for(int i = 0; i < arrays.Count; ++i)
    {
        handles[i] = GCHandle.Alloc(arrays[i], GCHandleType.Pinned);
        pointers[i] = (byte*)handles[i].AddrOfPinnedObject();
    }
    try
    {
        /* process pointers */
    }
    finally
    {
        for(int i = 0; i < arrays.Count; ++i)
        {
            handles[i].Free();
        }
    }
