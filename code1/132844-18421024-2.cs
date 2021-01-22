    public struct Const<T>
    {
        public T Value { get; private set; }
    
        public Const(T value)
        {
            this.Value = value;
        }
    }
    public Foo(Const<float> X, Const<float> Y, Const<float> Z)
    {
    // Can only read these values
    }
