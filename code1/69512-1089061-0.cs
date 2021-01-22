    using System.Security.Principal;
    public bool IsUserAdministrator()
    {
        //bool value to hold our return value
        bool isAdmin;
        try
        {
            //get the currently logged in user
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        catch (UnauthorizedAccessException ex)
        {
            isAdmin = false;
        }
        catch (Exception ex)
        {
            isAdmin = false;
        }
        return isAdmin;
    }
