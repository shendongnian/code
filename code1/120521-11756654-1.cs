    public abstract string AppSettingsRolesName { get; }
    List<string> authorizedRoles = new List<string>((ConfigurationManager.AppSettings[AppSettingsRolesName]).Split(','))
    if (!authorizedRoles.Contains(userRole))
    {
    Response.Redirect("UnauthorizedPage.aspx");
    }
