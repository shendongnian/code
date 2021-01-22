    //.NET 4 and above
    public delegate TResult Func<out TResult>()
    public delegate TResult Func<in T, out TResult>(T obj)
    //.NET 3.5
    public delegate TResult Func<T1, T2, TResult>(T1 obj1, T2 obj2)
    public delegate TResult Func<T1, T2, T3, TResult>(T1 obj1, T2 obj2, T3 obj3)
