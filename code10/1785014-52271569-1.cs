    private Brush _surNameColor = Brush.Black;
    public Brush SurNameColor
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
                SurNameColor = Brushes.Red;
            SetProperty(ref _errorID, value); }
    }
