    class BaseClass
    {
        // All non-derived class methods goes here...
        
        // For example:
        public int Id { get; private set; }
        public string Name { get; private set; }
        public void Run() {}
    }
    class BaseClass<TSelfReferenceType> : BaseClass
    {
        // All derived class methods goes here...
        
        // For example:
        public TSelfReferenceType Foo() {}
        public void Bar(TSelfRefenceType obj) {}
    }
