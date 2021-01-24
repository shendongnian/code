    private int _myField;
    public int BetterNameThanX
    {
        get { return _myField; }
        set
        {
            _myField = value;
            onPointeChanged();
        }
    }
