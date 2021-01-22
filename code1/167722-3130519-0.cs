    private string name;
    public string Name {
        get { return name; }
        set { Notify.SetField(ref name, value, PropertyChanged, this, "Name"); }
    }
