    public void GetUserDetail(string username, string password)
    {
        UserDetail userDetail = new UserDetail();
        try
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "mydomain.com", username, password);
    
            //Authenticate against Active Directory
            if (!principalContext.ValidateCredentials(username, password))
            {
                //Username or Password were incorrect or user doesn't exist
                return userDetail;
            }
    
            //Get the details of the user passed in
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, principalContext.UserName);
    
            //get the properties of the user passed in
            DirectoryEntry directoryEntry = userPrincipal.GetUnderlyingObject() as DirectoryEntry;
    
            userDetail.FirstName = directoryEntry.Properties["givenname"].Value.ToString();
            userDetail.LastName = directoryEntry.Properties["sn"].Value.ToString();
        }
        catch (Exception ex)
        {
           //Catch your Excption
        }
    
        return userDetail;
    }
