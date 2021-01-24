    public struct ResultOfStrategy
    {
        public IntPtr ptr;
        public double[] param;
    }
    public struct ResultOfStrategyImpl
    {
        public IntPtr ptr;
        public IntPtr param;
    }
    public static IntPtr Test(int length, out GCHandle[] handlesToBeFreed)
    {
        var result = new ResultOfStrategy[(int)length];
        for (int i = 0; i < (int)length; i++)
        {
            result[i].param = new double[10];
        }
        // Copy to new blittable object
        var result2 = new ResultOfStrategyImpl[result.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result2[i].ptr = result[i].ptr;
        }
        handlesToBeFreed = new GCHandle[length + 1];
        GCHandle handle;
        // try... finally trick to be sure that the code isn't interrupted by asynchronous exceptions
        try
        {
        }
        finally
        {
            for (int i = 0; i < result.Length; i++)
            {
                handle = GCHandle.Alloc(result2[i], GCHandleType.Pinned);
                handlesToBeFreed[i] = handle;
                result2[i].param = handle.AddrOfPinnedObject();
            }
            handle = GCHandle.Alloc(result2, GCHandleType.Pinned);
            handlesToBeFreed[result.Length] = handle;
        }
        return handle.AddrOfPinnedObject();
    }
    public static void FreeHandles(GCHandle[] handles)
    {
        if (handles != null)
        {
            for (int i = 0; i < handles.Length; i++)
            {
                handles[i].Free();
            }
        }
    }
