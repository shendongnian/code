    private List<int> _myList;
    public IEnumerable<int> MyList
    {
       get
       {
          return this._myList.ToList();
       }
    }
