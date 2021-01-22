    class HeapKey : IComparable<HeapKey>
    {
        public HeapKey(Guid id, Int32 value)
        {
            Id = id;
            Value = value;
        }
        public Guid Id { get; private set; }
        public Int32 Value { get; private set; }
        public int CompareTo(HeapKey other)
        {
            if (_enableCompareCount)
            {
                ++_compareCount;
            }
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            var result = Value.CompareTo(other.Value);
            return result == 0 ? Id.CompareTo(other.Id) : result;
        }
    }
