    public ConnectionSettings(
       [NotNullOrEmpty] string url, 
       [NotNull] string username, 
       [NotNull] string password,
       bool checkPermissions)
    {
        this.url = url;
        this.username = username;
        this.password = password;
        this.checkPermissions = checkPermissions;
    }
