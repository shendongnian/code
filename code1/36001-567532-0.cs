    public class Box<T> {
        public Box(T value) { this.Value = value; }
        public T Value { get; set; }
        public static implicit operator T(Box<T> box) {
            return box.Value;
        }
    }
