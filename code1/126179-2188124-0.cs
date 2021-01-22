    // declare the event
    public event EventHandler DateChanged;
    
    // declare backing field for the property
    private int _date;
    public int Date
    {
        get { return _date; }
        set
        {
            // bool indicating whether the new value is indeed 
            // different from the old one
            bool raiseEvent = _date != value;
            // assign the value to the backing field
            _date = value;
            // raise the event if the value has changed
            if (raiseEvent)
            {
                OnDateChanged(EventArgs.Empty);
            }
        }
    }
    
    protected virtual void OnDateChanged(EventArgs e)
    {
        EventHandler temp = this.DateChanged;
        // make sure that there is an event handler attached
        if (temp != null)
        {
            temp(this, e);
        }
    }
