    class Base
    {
        private string _someString;
        public Base(string someString)
        {
            _someString = someString != null ? someString.ToLower() : null;
        }
    }
    
    class Derived : Base
    {
        public Derived(string someString) : base(someString) { }
    }
