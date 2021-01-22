    MyClassName() {  //(Constructor)
        MyList = new ReadOnlyCollection<string>(_myList);
    }
    private List<string> _mylist;
    public ReadOnlyCollection<string> MyList { get; private set; }
