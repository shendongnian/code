    protected void Page_Load(object sender, EventArgs e)
    {
        // Now we can easily authenticate user in our code
        AuthenticateUserService authenticationProxy = 
             new AuthenticateUserService();
        bool isUserAuthenticated = 
             authenticationProxy.AuthenticateUser("jon", SomeHashMethod("foobar"));
    }
