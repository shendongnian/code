    private bool _controlVisibility;
    public bool ControlVisibility
    {
        get{ return _controlVisibility; }
        set
        { 
            _controlVisibility = value;
            control.Visibility = value;
        }
    }
