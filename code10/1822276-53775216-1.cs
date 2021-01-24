    // Demonstrations with 3 fields:
    public struct TestStruct : IEquatable<TestStruct>
    {
        private int _field1;
        private string _field2;
        private double _field3;
        // Concerns like constructors excluded for brevity...
        public override int GetHashCode() => EqualityUtility.GetHashCode(_field1, _field2, _field3);
        public override bool Equals(object obj) => obj is TestStruct other && Equals(other);
        public bool Equals(TestStruct other) =>
            EqualityUtility.Equals(_field1, other.field1, _field2, other.field2, _field3, other._field3);
        // Everything else would be implemented in terms of what you already have.
        public static bool operator ==(TestStruct a, TestStruct b) => a.Equals(b);
        public static bool operator !=(TestStruct a, TestStruct b) => !a.Equals(b);
    }
    public class TestClass : IEquatable<TestClass>
    {
        private int _field1;
        private string _field2;
        private double _field3;
        // Concerns like constructors excluded for brevity...
        public override int GetHashCode() => EqualityUtility.GetHashCode(_field1, _field2, _field3);
        public override bool Equals(object obj) => obj is TestClass other && Equals(other);
        public bool Equals(TestClass other) =>
            EqualityUtility.OtherIsNotNull(other) &&
            EqualityUtility.Equals(_field1, other.field1, _field2, other.field2, _field3, other._field3);
        public static bool operator ==(TestClass a, TestClass b) => (a is null && b is null) || (!(a is null) && a.Equals(b));
        public static bool operator !=(TestClass a, TestClass b) => !(a == b);
    }
