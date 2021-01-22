    [WebMethod]
    public ResultObj AddRole(string roleToAdd)
    {
        IIdentity identity = Thread.CurrentPrincipal.Identity;
        if (!identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException(
                    ConfigurationManager.AppSettings["NotAuthorizedErrorMsg"]);
        }
        // Remaining code to add role....
    }
