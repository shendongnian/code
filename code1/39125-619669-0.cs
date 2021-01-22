    public IEnumerable MyList
    {
        get
        {
             foreach (object o in mMyList)
                 yield return o;
        }
    }
