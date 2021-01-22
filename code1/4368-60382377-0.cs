    static string GeneratePassword(int characterCount)
    {
        string password = String.Empty;
        while(password.Length < characterCount)
            password += Regex.Replace(System.Web.Security.Membership.GeneratePassword(128, 0), "[^a-zA-Z0-9]", string.Empty);
        return password.Substring(0, characterCount);
    }
