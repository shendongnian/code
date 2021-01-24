    using System;
    using System.Text;
    using Security.Cryptography;
    ...
    public string HashPassword(string pswd, string saltValue, long iterations)
    {
        byte[] pswdBytes = Encoding.UTF8.GetBytes(pswd);
        byte[] saltByte = Encoding.UTF8.GetBytes(saltValue);
        byte[] hashedPassword = null;
        hashedPassword = BCryptPBKDF2.ComputeHash(PBKDF2HashAlgorithm.SHA512, pswdBytes, saltByte, iterations);
        return Convert.ToBase64String(hashedPassword);
    }
