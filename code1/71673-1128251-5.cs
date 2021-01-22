    public String Name
    {
        get { return this.name; }
        set
        {
            if (value != this.name)
            {
                this.RaisePropertyChanging();
                this.name = value;
                this.RaisePropertyChanged();
            }
        }
    }
    private String name = null;
    private void RaisePropertyChanged()
    {
        String propertyName =
           new StackTrace().GetFrame(1).GetMethod().Name.SubString(4);
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            handler(new PropertyChangedEventArgs(propertyName));
        }
    }
