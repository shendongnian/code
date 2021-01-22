    public class SimplerAES
    {
       private static byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
       private static byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
       private ICryptoTransform encryptor, decryptor;
       private UTF8Encoding encoder;
    
       public SimpleAES()
       {
          RijndaelManaged rm = new RijndaelManaged();
          encryptor = rm.CreateEncryptor(key, vector);
          decryptor = rm.CreateDecryptor(key, vector);
          encoder = new UTF8Encoding();
       }
    
       public string Encrypt(string unencrypted)
       {
          return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
       }
    
       public string Decrypt(string encrypted)
       {
          return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
       }
    
       public string EncryptToUrl(string unencrypted)
       { 
          return HttpUtility.UrlEncode(Encrypt(unencrypted));
       }
    
       public string DecryptFromUrl(string encrypted)
       {
          return Decrypt(HttpUtility.UrlDecode(encrypted));
       }
    
       public byte[] Encrypt(byte[] buffer)
       {
          MemoryStream encryptStream = new MemoryStream();
          using (CryptoStream cs = new CryptoStream(encryptStream, encryptor, CryptoStreamMode.Write))
          {
             cs.Write(buffer, 0, buffer.Length);
          }
          return encryptStream.ToArray();
       }
    
       public byte[] Decrypt(byte[] buffer)
       {
          MemoryStream decryptStream = new MemoryStream();
          using (CryptoStream cs = new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Write))
          {
             cs.Write(buffer, 0, buffer.Length);
          }
          return decryptStream.ToArray();
       }
    }
