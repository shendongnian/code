    public void AddUser(string userName, string userMail, string passwordHash)
    {
        // [...] Add a user to the database.
    }
    public void RegisterUser(string userName, string userMail, string passwordHash)
    {
        if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(...);
        if (string.IsNullOrEmpty(userMail)) throw new ArgumentNullException(...);
        if (string.IsNullOrEmpty(passwordHash)) throw new ArgumentNullException(...);
        if (!Checks.IsValidMail(userMail)) throw new ArgumentException(...);
        this.AddUser(userName, userMail, passwordHash);
        this.SaveToLog(LogEvent.UserRegistered, userName, this.IPAddress);
    }
