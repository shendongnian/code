    static void CheckIfMarshaled(ResultOfStrategy[] ros)
    {
        GCHandle h = default(GCHandle);
        try
        {
            try
            {
            }
            finally
            {
                h = GCHandle.Alloc(ros, GCHandleType.Pinned);
            }
            Console.WriteLine("ros was {0}", ros[0].ptr == h.AddrOfPinnedObject() ? "marshaled in place" : "marshaled by copy");
        }
        finally
        {
            if (h.IsAllocated)
            {
                h.Free();
            }
        }
    }
