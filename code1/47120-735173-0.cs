    public void AddRole(string roleName)
    {
        webSvc.Credentials = CredentialCache.DefaultCredentials;
        // Invoke the WebMethod
        webSvc.AddRole(roleName);
    }
