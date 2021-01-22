    interface ISomeClass
    {
        object ValueINeed { get; set; }
        // Only needed if you care about static type rather than using ValueINeed.GetType()
        Type TypeOfValue { get; }
    }
    class SomeClass<T> : ISomeClass
    {
        public T ValueINeed { get; set; }
        public Type TypeOfValue { get { return typeof(T); } }
        object ISomeClass.ValueINeed { get { return ValueINeed; } set { ValueINeed = (T)value; } }
    }
