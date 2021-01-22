    class Base {
        private List<string> _elems = new List<string>();
        protected ICollection<string> ElementStore { get { return _elems; } }
    }
    class Derived : Base {
        public Derived() {
            ElementStore.Add("Foo");
            ElementStore.Add("Bar");
        }
    }
