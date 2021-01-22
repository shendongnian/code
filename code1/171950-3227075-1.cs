    private string _yourText = string.Empty;
    public string YourText
    {
        get
        {
            return _yourText;
        }
        set 
        { 
            _yourText = value;
            UpdateValues(); 
        }
    }
