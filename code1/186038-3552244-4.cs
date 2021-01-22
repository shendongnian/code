    [MethodImpl(MethodImplOptions.NoOptimization)]
    private static void ThrowWithoutVariable()
    {
        try
        {
            BadGuy();
        }
        catch
        {
            throw;
        }
    }
