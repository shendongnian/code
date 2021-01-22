    // Tracks how many times the ReflectionOnlyResolveHandler has been requested.
    private static int  _subscribers = 0;
    /// <summary>
    /// Register or unregister the ReflectionOnlyResolveHandler.
    /// </summary>
    /// <param name="enable"></param>
    public static void SubscribeReflectionOnlyResolve(bool enable)
    {
        lock(_lock)
        {
            if (_subscribers > 0 && !enable) _subscribers -= 1;
            else if (enable) _subscribers += 1;
            if (enable && _subscribers == 1) 
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += ReflectionHelper.ReflectionOnlyResolveHandler;
            else if (_subscribers == 0) 
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= ReflectionHelper.ReflectionOnlyResolveHandler;
        }
    }
