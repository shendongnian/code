    using (var context = new PrincipalContext( ContextType.Domain ))
    {
      using (var user = UserPrincipal.FindByIdentity( context, IdentityType.SamAccountName, userName ))
      {
          user.SetPassword( "newpassword" );
          // or
          user.ChangePassword( "oldPassword", "newpassword" );
      }
    }
