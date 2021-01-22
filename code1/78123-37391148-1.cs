    protected string GetLoggedInUsername()
    {
        string UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; // Gives NT AUTHORITY\SYSTEM
        String UserName2 = Request.LogonUserIdentity.Name; // Gives NT AUTHORITY\SYSTEM
        String UserName3 = Environment.UserName; // Gives SYSTEM
        string UserName4 = HttpContext.Current.User.Identity.Name; // Gives actual user logged on (as seen in <ASP:Login />)
        string UserName5 = System.Windows.Forms.SystemInformation.UserName; // Gives SYSTEM
        return UserName4;
    }
