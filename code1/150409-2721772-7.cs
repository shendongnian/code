    public void SetupPasswordActionHook()
    {
    
        //Occurs when a user is created, a password is changed, or a password is reset.
        Membership.ValidatingPassword += Membership_ValidatingPassword;
    }
    
    void Membership_ValidatingPassword(object sender, ValidatePasswordEventArgs e)
    {
    
        // Gets a value that indicates whether the System.Web.Security.MembershipProvider.ValidatingPassword event is being raised during a 
        // call to the System.Web.Security.MembershipProvider.CreateUser() method.
    
        // true if the System.Web.Security.MembershipProvider.ValidatingPassword event is being raised during a call to the 
        // System.Web.Security.MembershipProvider.CreateUser() method; otherwise, false.
        bool isNewUser = e.IsNewUser;
    
        // Gets the password for the current create-user, change-password, or reset-password action.
    
        // The password for the current create-user, change-password, or reset-password action.
        string password = e.Password;
    
        // Gets the name of the membership user for the current create-user, change-password, or reset-password action.
    
        // The name of the membership user for the current create-user, change-password, or reset-password action.
        string username = e.UserName;
    
        // Gets or sets a value that indicates whether the current create-user, change-password, or reset-password action will be canceled.
    
        // true if the current create-user, change-password, or reset-password action will be canceled; otherwise, false. The default is false.
        e.Cancel = true;
    
        // Gets or sets an exception that describes the reason for the password-validation failure.
    
        // An System.Exception that describes the reason for the password-validation failure.
        e.FailureInformation = new Exception("This is why I failed your password");
    
    }
