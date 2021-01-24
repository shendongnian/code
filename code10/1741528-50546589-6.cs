    private void MyButtonCommandExecuteMethod()
    {
        this.IsLoggedIn = !this.IsLoggedIn;
    }
    private bool isLoggedIn;
    public bool IsLoggedIn
    {
        get
        {
            return this.isLoggedIn;
        }
        set
        {
            this.isLoggedIn = value;
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }
