    public string User
    {
        get { return user;}
        set { this.RaiseAndSetIfChanged(ref user, value);
    }
    public string Password
    {
        get { return password;}
        set { this.RaiseAndSetIfChanged(ref password, value);
    }
