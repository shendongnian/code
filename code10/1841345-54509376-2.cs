    public class TestClass
    {
        public int MyProperty { get; set; }
        public override int GetHashCode() {
            return MyProperty;
        }
    }
