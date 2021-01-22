    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            PropertyChanged.Raise(() => Name);
        }
    }
