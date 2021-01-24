    static void Main(string[] args)
    {
        SomeFunc<SomeClass>();
    }
    
    private static void SomeFunc<TData>() where TData : class, new()
    {
        object gsc = IReturnSomeGenericClassWithSomeClass();
    
        var check = gsc as GenericClass<TData>;
        System.Console.WriteLine(check == null ? "is null" : "is not null");
    }
    
    private static GenericClass<SomeClass> IReturnSomeGenericClassWithSomeClass() { return new GenericClass<SomeClass>(); }
    
    class SomeClass { }
    class GenericClass<T> { }
