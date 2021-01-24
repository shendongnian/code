    public void Foo<T>()
    {
        // We always know what this will be: we're specifying a closed constructed type
        Console.WriteLine(typeof(List<int>));
        // At compile-time, this isn't a closed, constructed type, because
        // it uses a type parameter as the type argument. At execution time,
        // it will take on a closed, constructed type based on the actual type
        // of T for this call.
        Console.WriteLine(typeof(List<T>));
        // This is a generic type definition, with no type argument
        Console.WriteLine(typeof(List<>));
    }
