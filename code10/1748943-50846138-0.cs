    private string userName;
    public string UserName 
    {
        get { return string.IsNullOrEmpty(userName) ? null : userName; }
        set { userName = value; }
    }
