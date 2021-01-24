    public void SaveSetting(string userLabel, string userNamelabel)
        {
            globalVariable.userlabel = userLabel;
            ApplicationDataContainer localSettings =
            ApplicationData.Current.LocalSettings;
            //Saving your setting  
            localSettings.Values[userLabel] = textBoxUsername.Text;
        }
