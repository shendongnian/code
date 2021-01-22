    class IndexAndValue : IComparable<IndexAndValue>
    {
        public int index;
        public double value;
        
        public int CompareTo(IndexAndValue other)
        {
            return value.CompareTo(other);
        }
    }
