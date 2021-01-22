    // The client can choose to put together an IEnumerable<...> by hand...    
    public MyClass(IEnumerable<KeyValuePair<object, object>> pairs)
    {
        // actual code that does something with the data pairs
    }
    // OR the client can pass whatever the heck he/she wants, as long as
    // some method for selecting the Xs and Ys from the enumerable data is provided.
    // (Sorry about the code mangling, by the way -- just avoiding overflow.)
    public static MyClass Create<T>
    (IEnumerable<T> source, Func<T, object> xSelector, Func<T, object> ySelector)
    {
        var pairs = source
            .Select(
                val => new KeyValuePair<object, object>(
                    xSelector(val),
                    ySelector(val)
                )
            );
        return new MyClass(pairs);
    }
