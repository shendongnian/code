    using (var context = new PrincipalContext( ContextType.Domain ))
    {
         using (var user = UserPrincipal.FindByIdentity( context,
                                                         IdentityType.SamAccountName,
                                                         name ))
         {
              if (user.IsAccountLockedOut())
              {
                  ... your code here...
              }
         }
    }
