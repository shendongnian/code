    public string Status
    {
        get
        {
            return (string)this.Properties["status"];
        }
        set
        {
            this.Properties["status"] = value;
            NotifyPropertyChanged("Status");
        }
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Status = "Online";
        ...
    }
