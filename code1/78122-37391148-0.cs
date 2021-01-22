    protected string GetLoggedInUsername()
    {
        string UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; // gives NT AUTHORITY\SYSTEM
        String UserName2 = Request.LogonUserIdentity.Name; // gives NT AUTHORITY\SYSTEM
        String UserName3 = Environment.UserName; // gives SYSTEM
        string UserName4 = HttpContext.Current.User.Identity.Name; // gives actual user logged on (as seen in <ASP:Login />)
        string UserName5 = System.Windows.Forms.SystemInformation.UserName; // gives SYSTEM
        return UserName4;
    }
