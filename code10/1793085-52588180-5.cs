    static ICredentials GetCredentials(string userName, string password)
    {
        var securePassword = new SecureString();
        foreach (var c in password)
        {
            securePassword.AppendChar(c);
        }
        return new SharePointOnlineCredentials(userName, securePassword);
    }
