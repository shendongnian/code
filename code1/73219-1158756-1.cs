    public User CreateUser(string userName, string password, string Email, string emailAlerts, string channelDescription)    
    {
        var parameters = new Hashtable();
        parameters.Add("Username", userName);
        parameters.Add("Password", password);
        parameters.Add("EmailAlerts", emailAlerts);
        parameters.Add("ChannelDescription", channelDescription);
        ParameterChecker.CheckForNull(parameters);
 
        // etc etc
    }
