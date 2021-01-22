    public class Node<T> {
        public Node<T> this[string key] {
            get { return GetChildNode(key); }
            set {
                if (value is DummyNode<T>) {
                    GetChildNode(key).Value = value.Value;
                } else {
                    // do something, ignore, throw exception, depending on the problem
                }
            }
        } 
        public static implicit operator T(Node<T> value) {
            return value.Value;
        }
        private class DummyNode<T> : Node<T> {
        }
        public static implicit operator Node<T>(T value) {
            return new DummyNode<T> { Value = value };
        }
        public T Value { get; set; }
    }
