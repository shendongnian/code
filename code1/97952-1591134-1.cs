    public static MethodInfo GetInfo<T>(Action<T> action)
    {
        return action.Method;
    }
    public static MethodInfo GetInfo<T, TResult>(Func<T, TResult> func)
    {
        return func.Method;
    }
    public static MethodInfo GetInfo<T, U, TResult>(Func<T, U, TResult> func)
    {
        return func.Method;
    }   
    public static int Target(int v1, int v2)
    {
        return v1 ^ v2;
    } 
    static int Main(string[] args)
    {
        var mi = GetInfo<string[], int>(Main);
        Console.WriteLine(mi.Name);
        var mi2 = GetInfo<int, int, int>(Target);
        Console.WriteLine(mi2.Name);
        return 0;
    }
