    public class HeapKey : IComparable<HeapKey>
    {
        public HeapKey(int value)
        {
            Value = value;
        }
        public int Value { get; private set; }
        public int CompareTo(HeapKey other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            return Value.CompareTo(other.Value);
        }
    }
