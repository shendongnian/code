    public static void SafeDispose(this IDisposable obj)
    {
        if (obj != null)
            obj.Dispose();
    }
