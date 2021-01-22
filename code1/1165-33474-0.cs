    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string nickName;
    public string NickName    {
        [DebuggerStepThrough]
        get { return nickName; }
        [DebuggerStepThrough]
        set { this.nickName = value; }
    }
