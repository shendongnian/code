    private interface IMyClass
    {
        object UntypedValue { get; }
    }
    private class MyClass<T> : IMyClass
    {
        T Value { get; set; }
        object UntypedValue { get { return Value; } }
    }
