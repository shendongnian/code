    class ReadOnlyField<T> {
        public T Value {
            get { return _Value; }
            set { 
                if (Frozen) throw new InvalidOperationException();
                _Value = value;
            }
        }
        private T _Value;
        private bool Frozen;
        public void Freeze() {
            Frozen = true;
        }
    }
    class Foo {
        public readonly ReadOnlyField<int> FakeReadOnly = new ReadOnlyField<int>();
        // forward to allow freeze of multiple fields
        public void Freeze() {
            FakeReadOnly.Freeze();
        }
    }
