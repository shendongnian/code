    class Foo
    {
        private SomeObject myObject;
        public SomeObject MyObject
        {
            get { return myObject; }
        }
    
        public Foo()
        {
            myObject = new SomeObject();
        }
    }
