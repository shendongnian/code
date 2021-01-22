    [System.Runtime.CompilerServices.MethodImpl(
     System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    public void PopularMethod()
    {
        // 1 == skip frames, false = no file info
        var callingMethod = new System.Diagnostics.StackTrace(1, false)
             .GetFrame(0).GetMethod();
    }
