    protected void WindowsAuthentication_OnAuthenticate(object sender, WindowsAuthenticationEventArgs e)
    {
        if (!Roles.IsUserInRole(e.Identity.Name, "Users"))
        {
            Roles.AddUsersToRole(new string[] { e.Identity.Name }, "Users");
        }
    }
