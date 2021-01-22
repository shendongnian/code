    public class MyAppUser : IPrincipal
    {
       private IIdentity _identity;
    
       private UserId { get; private set; }
       private IsAdmin { get; private set; } // perhaps use IsInRole
    
       MyAppUser(userId, isAdmin, iIdentity)
       {
          if( iIdentity == null ) 
             throw new ArgumentNullException("iIdentity");
          UserId = userId;
          IsAdmin = isAdmin;
          _identity = iIdentity;          
       }
       #region IPrincipal Members
       public System.Security.Principal.IIdentity Identity
       {
          get { return _identity; }
       }
    
       // typically this stores a list of roles, 
       // but this conforms with the OP question
       public bool IsInRole(string role)
       {  
          if( "Admin".Equals(role) )
             return IsAdmin;     
    
          throw new ArgumentException("Role " + role + " is not supported");
       }
       #endregion
    }
