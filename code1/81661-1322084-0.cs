    GCHandle handle = new GCHandle();
    try
    {
      handle = GCHandle.Alloc(fooz, GCHandleType.Pinned);
      // Use fooz.
    }
    finally
    {
      if (handle.IsAllocated)
        handle.Free();
    }
