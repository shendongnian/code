    public class MyClass {
        public static readonly MyClass DefaultInstance = new MyClass();
        public int Value { get; set; }
        public MyClass() {
            this.Value = 10;
        }
        public override int GetHashCode() {
            return Value.GetHashCode();
        }
        public override bool Equals(Object obj) {
            if (obj == this) return true;
            var other = obj as MyClass;
            return other?.Value == this.Value;
        }
    }
