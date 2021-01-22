    public ConnectionSettings(
        Uri url, string username, string password, bool checkPermissions)
    {
        this.username = Guard.Argument(() => username).NotNull();
        this.password = Guard.Argument(() => password).NotNull();
    	this.url = Guard.Argument(() => url).NotNull().Https();
        this.checkPermissions = checkPermissions;
    }
