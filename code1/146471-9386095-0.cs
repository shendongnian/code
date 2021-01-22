    public static Guid ToGuid(string src)
    {
        byte[] stringbytes = Encoding.UTF8.GetBytes(src);
        byte[] hashedBytes = new System.Security.Cryptography
            .SHA1CryptoServiceProvider()
            .ComputeHash(stringbytes);
        Array.Resize(ref hashedBytes, 16);
        return new Guid(hashedBytes);
    }
