    public static void Process<TResult, TList>(this Person<TList> p)
        where TList : IEnumerable<TResult>
    {
        Console.WriteLine(p.Value.Any());
    }
