    public class MyObject : IComparable
    {
        public int Value { get; set; }
        public int CompareTo(object other)
        {
            MyObject rhs = object as MyObject;
            if (rhs == null) return -1;
            return (Value - rhs.Value);
        }
    }
