    public static void Process<TResult>(this IPerson<IEnumerable<TResult>> p)
    {
        // Do something with .Any().
        Console.WriteLine(p.Value.Any());
    }
