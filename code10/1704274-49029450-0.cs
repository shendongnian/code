         try
            {    // assuming _userID is the user-id to be authenticated in AD.
                PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, "domain.name", "DC=domain,DC=name", ContextOptions.SimpleBind, "bindUserID", "bindPassword");
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, _userID);
                  if(null != oUserPrincipal){
                  // user-authentication successful, continue further.
                  }
                 else{
                  // return the message that the user-id could not be found.
                  // preferably the user-id should be **SamAccountName**
                  }
            }
            catch (Exception e)
            {
                message = e.ToString();
            }
