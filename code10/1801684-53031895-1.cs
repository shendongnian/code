    private Messages _msg;
    public Messages Msg
    {
        get { return _msg ?? (_msg = new Messages()); }
        set { SetProperty(ref _msg, value); }
    }
