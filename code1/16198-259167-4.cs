     using System.Security.Principal;
    
     // ...
     GenericIdentity identity = new GenericIdentity("M.Brown");
     identity.IsAuthenticated = true;
            
     // ...
     System.Threading.Thread.CurrentPrincipal =
        new GenericPrincipal(
            identity,
            new string[] { "Role1", "Roll2" }
        );
     //...
     if (!System.Threading.Thread.CurrentPrincipal.IsInRole("Roll1"))
     {
          Console.WriteLine("Permission denied");
          return;
     }
