    private List<string> theList;
    public List<string> LazyList
    {
      get { return theList ?? (theList = new List<string>()); }
    }
