    private List<string> myList;
    public List<string> MyProp 
    {
        get { return myList ?? (myList= new List<string>()); }
    }
