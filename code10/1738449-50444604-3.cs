    public MainWindow()
    {
        InitializeComponent();
    
        this.contentControl.Content = getLogInControl();
    }
    private LogInControl getLogInControl()
    {
        LogInControl logInControl = new LogInControl();
        logInControl.OnSuccessfulLogin += (senser, e) =>
        {
            ChangeContentControl("Check");
        };
        return logInControl;
    }
    private CheckControl getCheckControl()
    {
        CheckControl checkControl = new CheckControl();
        checkControl.LogOutClick += (senser, e) =>
        {
            ChangeContentControl("LogIn");
        };
        return checkControl;
    }
    
    public void ChangeContentControl(string kindContentControl)
    {
        switch (kindContentControl)
        {
            case "LogIn":
                {
                    ...
                    this.contentControl.Content = getLogInControl();
                }
                break;
            case "Check":
                {
                    ...
                    this.contentControl.Content = getCheckControl();
                }
                break;
        }
    }
