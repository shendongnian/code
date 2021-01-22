    class Foo
    {
       List<Bar> _myList;
       ...
       public IEnumerable<Bar> GetList() { return _myList.AsReadOnly(); }
    }
