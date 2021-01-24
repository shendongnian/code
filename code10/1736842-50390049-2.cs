    public MainWindow()
    {
        InitializeComponent();
        var loginControl = new LoginControl();
        loginControl.LoginClick += (senser, e) =>
        {
             this.contentControl.Content = new CheckInCheckOutControl();
        }
        this.contentControl.Content = loginControl;
    }
