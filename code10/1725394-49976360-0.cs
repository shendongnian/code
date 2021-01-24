    [DebuggerDisplay("{ value }")]
    public class Foo<T>
    {
        private readonly T value;
        public Foo(T value)
        {
            this.value = value;
        }
    }
