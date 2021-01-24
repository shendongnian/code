    public void SaveSetting(string userLabel, string userNamelabel)
    {
        var appSettings = new AppSettings();
        appSettings.UserName = textBoxUsername.Text;
    }
    private string ReadSetting(string userLabel)
    {
        var appSettings = new AppSettings();
        return appSettings.UserName ?? "User not signed in";
    }
