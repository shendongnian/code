    private string _username;         
    public string Username
    {
        get { return Firstname + '_' + Lastname + GenerateRandomNo(); }
        set
        {
            _username = value;
            NotifyOfPropertyChange("Username");
            NotifyOfPropertyChange("Firstname");
            NotifyOfPropertyChange("Lastname");
        }
    }
