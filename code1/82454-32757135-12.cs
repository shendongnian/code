    private string testProperty;
    public string TestProperty
    {
        get { return testProperty; }
        set { changeProperty(ref testProperty, value); }
    }
