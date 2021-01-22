     // This will return an encrypted string based on the unencrypted parameter
     public static string Encrypt(this string DecryptedValue)
     {
          HttpServerUtility.UrlTokenEncode(MachineKey.Protect(Encoding.UTF8.GetBytes(DecryptedValue.Trim())));
     }
     // This will return an unencrypted string based on the parameter
     public static string Decrypt(this string EncryptedValue)
     {
          Encoding.UTF8.GetString(MachineKey.Unprotect(HttpServerUtility.UrlTokenDecode(EncryptedValue)));
     }
