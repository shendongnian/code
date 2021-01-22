    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        // get handler (usually a local event variable or just the event)
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, e);
        }
    }
