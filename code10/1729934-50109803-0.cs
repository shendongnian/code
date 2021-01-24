    private bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
        set 
        {
            _isActive = value;
            if (value) // if the value assigned is true
            {
                someButton.IsEnabled = true; // enable a button, for example
            }
        }
    }
