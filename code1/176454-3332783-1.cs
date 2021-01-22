    public static void DoSomething<T>(this T item)
        where T : IComparable
    { /* whatever */ }
    public static void DoSomething<T>(this T item)
        where T : IDisposable
    { /* whatever else */ }
