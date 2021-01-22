    class MyClass
    {
        Dictionary<string, MyType> collection;
        public MyType this[string name]
        {
            get { return collection[name]; }
            set { collection[name] = value; }
        }
    }
    
    MyClass myClass = ...
    MyType myType = myClass["myKey"];
