    var buffer = IntPtr.Zero;
    try
    {
        buffer = Marshal.AllocHGlobal(size);
        GC.AddMemoryPressure(size);
        
        // ... use buffer ...
    }
    finally
    {
        Marshal.FreeHGlobal(buffer);
        GC.RemoveMemoryPressure(size);
    }
