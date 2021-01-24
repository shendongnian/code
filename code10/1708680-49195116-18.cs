    private List<string> names = new List<string>() { "Michael", "Mark", "Luke", "John" };
    public List<string> Names
    {
        get { return names.ToList() ; }
        set { names = value; }
    }
