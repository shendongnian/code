    public class PolyVar<T>
    {
        public PolyVar()
        {
        }
        public PolyVar(T value)
        {
            Value = value;
        }
        // note: no reason to explicitly declare the backing field
        public T Value { get; set; }
        // return the string representation of the current value
        public override string ToString() => Value.ToString();
        // allow any type to be implicitly a PolyVar
        public static implicit operator PolyVar<T>(T value) => new PolyVar<T>(value);
    }
