    var iter = ((IEnumerable<char>)"hello").GetEnumerator();
    
    //with closure
    {
        Func<object> f =
            () =>
                {
                    iter.MoveNext();
                    return iter.Current;
                };
        Console.WriteLine(f());
        Console.WriteLine(f());
    }
    
    //without closure
    {
        Func<IEnumerator, object> f =
            ie =>
                {
                    ie.MoveNext();
                    return ie.Current;
                };
        Console.WriteLine(f(iter));
        Console.WriteLine(f(iter));
    }
