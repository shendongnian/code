    public double Days
    {
        get { return _span.Days; }
        set
        {
            TimeSpan ts = new TimeSpan();
            double val = value > 0 ? value : 0;
            ts = TimeSpan.FromDays(val);
            _span.Add(ts);
            this.OnPropertyChanged("Days");
            this.OnPropertyChanged("Span");
        }
    }
    // This is preferred way for handling property changes
    private event PropertyChangedEventHandler propertyChanged;
    public event PropertyChangedEventHandler PropertyChanged
    {
        add { this.propertyChanged += value; }
        remove { this.propertyChanged -= value; }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = this.propertyChanged;
        if (null != handler)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
