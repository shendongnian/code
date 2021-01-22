    using (var context = new PrincipalContext( ContextType.Domain ))
    {
         using (var user = UserPrincipal.FindByIdentity( context, IdentityType.SamAccountName, userName ))
         {
             if (user != null)
             {
                 user.ChangePassword( oldPassword, newPassword );
                 // or if you don't have the user's old password and
                 // do have enough privileges.
                 // user.SetPassword( newPassword );        
             }
        }
    }
