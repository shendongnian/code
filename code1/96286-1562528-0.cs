    class MyType {
        private bool isFrozen;
        public MyType Freeze() {
            isFrozen = true;
            return this;
        }
        protected void ThrowIfFrozen() {
            if (isFrozen) throw new InvalidOperationException("Too cold");
        }
        private int id;
        public int Id {
            get { return id; }
            set { ThrowIfFrozen(); id = value; }
        }
        private string name;
        public string Name {
            get { return name; }
            set { ThrowIfFrozen(); name = value; }
        }
    }
