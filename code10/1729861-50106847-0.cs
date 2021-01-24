    List<object> someList = new List<object>();
    
    public ReadOnlyCollection<object> SomeList
    {
        get
        {
            return someList.AsReadOnly();
        }
    }
