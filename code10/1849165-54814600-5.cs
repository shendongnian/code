    public string globalUserLabel;
    public void SaveSetting(string userLabel, string userNamelabel)
        {
            globalUserLabel = userLabel;
            ApplicationDataContainer localSettings =
            ApplicationData.Current.LocalSettings;
            //Saving your setting  
            localSettings.Values[userLabel] = textBoxUsername.Text;
        }
    public home()
        {
            this.InitializeComponent();
            UserNameLabelBox.Text = ReadSetting(LoginPage.globalUserLabel );
        }
