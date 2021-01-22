    class TestClass
    {
        public int propertyOne {get;set;}
        public List<int> propertyTwo {get; private set;}
        public TestClass() : this(new List<int>()) { }
        public TestClass(List<int> initialList)
        {
            propertyTwo = initialList;
        }
    }
    ...
    var results = from x in MyOtherClass
    select new TestClass(x.propertyList)
    {
        propertyOne = x.propertyFirst
    };
