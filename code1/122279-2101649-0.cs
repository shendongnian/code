    using (var context = new PrincipalContext( ContextType.Domain ))
    {
         using (var group = GroupPrincipal.FindByIdentity( context, "groupname" ))
         {
               var users = group.GetMembers( true ); // recursively enumerate
               ...
         }
    }
