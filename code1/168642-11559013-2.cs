    private string _labelText;
    public string labelText
    {
        get { return _labelText; }
        set
        {
            _labelText = value;
            updateLabelText(_labelText); //setting label to value
       }
    }
