    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void TargetMethod()
    {
        StackFrame fr = new StackFrame(1, false);
        Console.WriteLine(fr.GetMethod().Name);
    }
