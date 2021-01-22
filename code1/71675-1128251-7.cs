    public String Name
    {
        get { return this.name; }
        set
        {
            if (value != this.name)
            {
                String propertyName = MethodBase.GetCurentMethod().Name.SubString(4);
                this.RaisePropertyChanging(propertyName);
                this.name = value;
                this.RaisePropertyChanged(propertyName);
            }
        }
    }
    private String name = null;
