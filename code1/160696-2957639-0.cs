     using (var context = new PrincipalContext( ContextType.Domain )) 
     {
          using (var user = UserPrincipal.FindByIdentity( context, "username" ))
          {
              var groups = user.GetAuthorizationGroups();
              ...
          }
     }
