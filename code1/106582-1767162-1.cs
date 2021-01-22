    [TypeConverter(typeof(MyNumberArrayConverter))]
    public class MyNumberArray : IEnumerable<int>
    {
        List<int> _values;
        public MyNumberArray() { _values = new List<int>(); }
        public MyNumberArray(IEnumerable<int> values) { _values = new List<int>(values); }
        public static implicit operator List<int>(MyNumberArray arr)
        { return new List<int>(arr._values); }
        public static implicit operator MyNumberArray(List<int> values)
        { return new MyNumberArray(values); }
        public IEnumerator<int> GetEnumerator()
        { return _values.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator()
        { return ((IEnumerable)_values).GetEnumerator(); }
    }
