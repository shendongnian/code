    private string _surNameColor = "Black";
    public string SurNameColor
    {
        get { return _surNameColor; }
        set { SetProperty(ref _surNameColor, value); }
    }
    private errorID _errorID;
    public errorID ErrorID
    {
        get { return _errorID; }
        set { 
            if(ErrorID.HasFlag(errorID.SURNAME_DIFF))
                SurNameColor = "Red";
            SetProperty(ref _errorID, value); }
    }
