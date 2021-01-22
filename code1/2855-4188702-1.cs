    public struct Foo<T>
    {
        public T Value { get; private set; }
        
        public static Foo<T> operator +(Foo<T> LHS, Foo<T> RHS)
        {
            return new Foo<T> { Value = LHS.Value + (dynamic)RHS.Value };
        }
    }
