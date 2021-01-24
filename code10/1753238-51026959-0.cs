    public static string WindowsEncrypted(string text)
    {
        byte[] plainBinary= Encoding.Unicode.GetBytes(text);
        byte[] encrypted = ProtectedData.Protect(plainBinary, null, DataProtectionScope.LocalMachine);
        string base64 = Convert.ToBase64String(encrypted);
        // Return a url-safe string
        return base64.Replace("+", "-").Replace("/", "_").Replace("=", ".");
    }
    public static string WindowsDecrypted(string text)
    {
        string base64 = text.Replace("-", "+").Replace("_", "/").Replace(".", "=");
        byte[] encrypted = Convert.FromBase64String(base64);
        byte[] plainBinary = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.LocalMachine);
        return Encoding.Unicode.GetString(plainBinary);
    }
