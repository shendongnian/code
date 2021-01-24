    LogInControl logInControl = new LogInControl();
    CheckControl checkControl = new CheckControl();
    public MainWindow()
    {
        InitializeComponent();
        logInControl.OnSuccessfulLogin += (senser, e) =>
        {
            ChangeContentControl("Check");
        };
        checkInControl.LogOutClick += (senser, e) =>
        {
            ChangeContentControl("LogIn");
        };
        this.contentControl.Content = logInControl;
    }
    public void ChangeContentControl(string kindContentControl)
    {
        switch (kindContentControl)
        {
            case "LogIn":
                {
                    ...
                    this.contentControl.Content = logInControl ;
                }
                break;
            case "Check":
                {
                    ...
                    this.contentControl.Content = checkControl;
                }
                break;
        }
    }
