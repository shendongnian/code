    Span<byte> Allocate() => new Span<byte>(new byte[256]);
    
    void CallAndPrint<T>(Func<T> valueProvider) // no generic requirements for T
    {
        object value = valueProvider.Invoke(); // boxing!
    
        Console.WriteLine(value.ToString());
    }
    
    void Demo()
    {
        Func<Span<byte>> spanProvider = Allocate;
        CallAndPrint<Span<byte>>(spanProvider);
    }
