    protected void createUserWizard_CreateUserError(object sender, CreateUserErrorEventArgs arguments)
    {
        LogCreateUserError(arguments.CreateUserError, "no user info");
    }
     private void LogCreateUserError(MembershipCreateStatus status, string username)
    {
        string reasonText = status.ToString();
        switch (status)
        {
            case MembershipCreateStatus.DuplicateEmail:
            case MembershipCreateStatus.DuplicateProviderUserKey:
            case MembershipCreateStatus.DuplicateUserName:
                reasonText = "The user details you entered are already registered.";
                break;
            case MembershipCreateStatus.InvalidAnswer:
            case MembershipCreateStatus.InvalidEmail:
            case MembershipCreateStatus.InvalidProviderUserKey:
            case MembershipCreateStatus.InvalidQuestion:
            case MembershipCreateStatus.InvalidUserName:
            case MembershipCreateStatus.InvalidPassword:
                reasonText = string.Format("The {0} provided was invalid.", status.ToString().Substring(7));
                break;
            default:
                reasonText = "Due to an unknown problem, we were not able to register you at this time";
                break;
        }
       //DO whatever with it.. ....
    }
