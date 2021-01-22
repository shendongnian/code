    using System.Security.Principal;
    public string GetUserName()
            {                
    
                return( WindowsIdentity.GetCurrent().Name);
                
                
            }
