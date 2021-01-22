    public double Days
    {
        get { return _span.Days; }
        set
        {
            double val = value > 0 ? value : 0;
            // TimeSpan is an immutable struct, must store the result of any
            // operations on it
            _span = TimeSpan.FromDays(val);
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
