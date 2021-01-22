    public static byte[] CreateHashedPassword(string password, byte[] salt) 
    { 
        SHA1 sha1 = SHA1.Create(); 
        byte[] pwd = CustomHelpers.StringToByteArray(password);
        byte[] pwdPlusSalt = new byte[salt.Length + pwd.Length];
        salt.CopyTo(pwdPlusSalt, 0); 
        pwd.CopyTo(pwdPlusSalt, salt.Length); 
    
        return sha1.ComputeHash(pwdPlusSalt);
    }
