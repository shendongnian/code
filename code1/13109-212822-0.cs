    using System.Security.Cryptography;
    public static string EncodePasswordToBase64(string password)
    {  byte[] bytes   = Encoding.Unicode.GetBytes(password);
       byte[] dst     = new byte[bytes.Length];
       byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(dst);
       return Convert.ToBase64String(inArray);
    }  
