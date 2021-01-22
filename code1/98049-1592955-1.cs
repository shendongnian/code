    class Foo {
        public int FakeReadOnly {
            get { return _FakeReadOnly; }
            set {
                if (!instanceIsFrozen)
                    throw new InvalidOperationException();
                _FakeReadOnly = value;
            }
        }
        private int _FakeReadOnly;
        private bool instanceIsFrozen;
        public void FreezeInstance() {
            instanceIsFrozen = true;
        }
    }
