    public static string ProtectPassword(string password)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(password);
        byte[] protectedPassword = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(protectedPassword);
    }
    
    public static string UnprotectPassword(string protectedPassword)
    {
        byte[] bytes = Convert.FromBase64String(protectedPassword);
        byte[] password = ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser);
        return Encoding.Unicode.GetString(password);
    }
