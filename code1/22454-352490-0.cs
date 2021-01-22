    public class MyClass
    {
        public MyClass(..., IList<MyType> items)
        {
            ...
            _myReadOnlyList = new List<MyType>(items).AsReadOnly();
        }
    
        public IList<MyType> MyReadOnlyList
        {
            get { return _myReadOnlyList; }
        }
        private IList<MyType> _myReadOnlyList
    
    }
