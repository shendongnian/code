    GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
    try
    {
    	IntPtr pointer = handle.AddrOfPinnedObject();
    }
    finally
    {
    	if (handle.IsAllocated)
    	{
    		handle.Free();
    	}
    }
