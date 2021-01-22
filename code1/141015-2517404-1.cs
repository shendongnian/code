    class MyClass
    {
        Dictionary<string, MyType> collection;
        public MyType this[string name]
        {
            get { return collection[name]; }
            set { collection[name] = value; }
        }
    }
    
    // Getting data from indexer.
    MyClass myClass = ...
    MyType myType = myClass["myKey"];
    // Setting data with indexer.
    MyType anotherMyType = ...
    myClass["myAnotherKey"] = anotherMyType;
