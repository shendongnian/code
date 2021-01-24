    private int _myIndex;
    public int MyIndex
    {
        get
        {
            return this._myIndex;
        }
        set
        {
            this._myIndex = value;
            OnPropertyChanged(nameof(MyIndex));
            OnPropertyChanged(nameof(IsLowerThanTheHighestIndex));
        }
    }
