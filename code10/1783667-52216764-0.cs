    private bool userstatus;
    public bool UserStatus
    {
        get { return (userstatus == false) ? true : false; }
        set
        {
            userstatus = value;
            OnPropertyChanged("UserStatus");
        }
    }
