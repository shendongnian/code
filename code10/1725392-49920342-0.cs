    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class Foo<T>
    {
        private readonly T value;
    
        public Foo(T value)
        {
            this.value = value;
        }
    
        private string GetDebuggerDisplay()
        {
            var val = value is string ? "\"" + value + "\"" : value?.ToString();
            return $"Foo<{typeof(T).Name.ToLower()}> {{ {val} }}";
        }
    }
