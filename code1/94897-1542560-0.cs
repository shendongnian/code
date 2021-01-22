    private object[] myProperty
    public List<object> MyProperty
    {
        get
        {
            return p.ToList();
        }
        set
        {
            //initialise if necessary
            p = value.ToArray();
        }
    }
