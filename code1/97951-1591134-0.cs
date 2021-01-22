    public static MethodInfo GetInfo<T>(Action<T> action)
    {
        return action.Method;
    }
    public static MethodInfo GetInfo<T, TResult>(Func<T, TResult> func)
    {
        return func.Method;
    }
    static int Main(string[] args)
    {
        var mi = GetInfo<string[], int>(Main);
        Console.WriteLine(mi.Name);
        return 0;
    }
