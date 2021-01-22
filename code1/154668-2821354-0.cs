    public double Days
    {
        get { return _span.Days; }
        set
        {
            TimeSpan ts = new TimeSpan();
            double val = value > 0 ? value : 0;
            ts = TimeSpan.FromDays(val);
            _span.Add(ts);
            this.OnNotifyPropertyChanged("Days");
            this.OnNotifyPropertyChanged("Span");
        }
    }
