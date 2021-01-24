    public class TestClass : IComparable<string>
    {
        public string Value { get; private set; }
        public int CompareTo(string other) { return Value.CompareTo(other); }
    }
