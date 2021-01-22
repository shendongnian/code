    class B
    {
        string SomeValue1 { get; set; }
        int SomeValue2 { get; set; }
        decimal SomeValue3 { get; set; }
    } 
    
    interface ICountable<T>
    {
        T Value { get; }
        int Count { get; }
    }
    
    class C : ICountable<B>
    {
        B Value { get; set; }
        int Count { get; set; }
    }
