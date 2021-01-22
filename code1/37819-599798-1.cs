    static void Foo<T>() where T : new()
    {
        T t = new T();
        Console.WriteLine(t.ToString()); // works fine
        Console.WriteLine(t.GetHashCode()); // works fine
        Console.WriteLine(t.Equals(t)); // works fine
        // so it looks like an object and smells like an object...
        // but this throws a NullReferenceException...
        Console.WriteLine(t.GetType()); // BOOM!!!
    }
    
