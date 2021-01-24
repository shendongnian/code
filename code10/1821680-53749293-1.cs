    private bool _isBusy;
    public bool IsBusy
    {
        get{return _isBusy;}
        set { _isBusy=value; RaisePropertyChanged(); }
    }
