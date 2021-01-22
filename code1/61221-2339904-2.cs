    private string _name;
    public string Name
    {
        get { return _name; }
        set { this.NotifySetProperty(ref _name, value, () => this.Name); }
    }
