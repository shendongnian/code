    class MyClass {
        //this is a simple property with a backing field
        private int _someInt = 0;
        public int SomeInt {
            get { return _someInt; }
            set { _someInt = value; }    //"value" is a keyword meaning the rhs of a property set expression
        }
        //this is a similar property as an "auto property", the initializer is optional
        public int OtherInt { get; set; } = 0;
        //this is an auto-property with a public getter, but a protected setter
        public string SomeString { get; protected set; }
    }
