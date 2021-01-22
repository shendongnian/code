    using System.Security.Principal;
    public string GetUserName2()
            {
                //WindowsPrincipal winp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
    
                return( WindowsIdentity.GetCurrent().Name);
                
                // winp.Identity.Name);
            }
