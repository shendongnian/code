    class Foo
    {
       List<Bar> _myList;
       ...
       public ReadOnlyCollection<Bar> GetList() { return _myList.AsReadOnly(); }
    }
