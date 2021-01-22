    using System.Security.Principal;
    public bool IsUserAdministrator()
    {
        //bool value to hold our return value
        bool isAdmin;
        WindowsIdentity user = null;
        try
        {
            //get the currently logged in user
            user = WindowsIdentity.GetCurrent();
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
        finally
        {
            if (user != null)
                user.Dispose();
        }
        return isAdmin;
    }
