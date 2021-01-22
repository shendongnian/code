    public class TypedValue<TValue>
    {
        public TypedValue(TValue value)
        {
            Value = value;
        }
        public TValue Value { get; private set; }
    }
