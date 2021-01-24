    public static string Sign(string text)
    {
        var privateRSAkey = Crypto.DecodeRsaPrivateKey(PermissionKey);
        var rsa = privateRSAkey;
        var hasher = new SHA1CryptoServiceProvider();
        var e = new UTF8Encoding(true);
        var bytesFirmados = rsa.SignData(e.GetBytes(text), hasher);
        return Convert.ToBase64String(bytesFirmados);
    }
