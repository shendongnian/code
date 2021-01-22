    private string name;
    public string Name
    {
        get { return name; }
        set { SetField(ref name, value, () => Name); }
    }
