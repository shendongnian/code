    protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool successfulLogin = false;
        string userName = Membership.GetUserNameByEmail(LoginUser.UserName); //the email address
        LoginUser.UserName = userName; //+++ Set username recovered by email. 
        successfulLogin = Membership.ValidateUser(userName, LoginUser.Password);
        if (successfulLogin)
            FormsAuthentication.SetAuthCookie(userName, true);
        e.Authenticated = successfulLogin;
    }
