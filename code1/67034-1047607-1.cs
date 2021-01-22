    class Foo
    {
        private readonly MyObject myObject;
        public SomeObject MyObject { get { return myObject; } }
    
        public Foo()
        {
            myObject = new MyObject();
            // logic 
        }
    }
