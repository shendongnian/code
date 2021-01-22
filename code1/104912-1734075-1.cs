    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Hasher
    {
      class Program
      {
        static void Main(string[] args)
        {
          const string PrivateKey = "whatever";
    
          string date = "Sat, 14 Nov 2009 09:47:53 GMT";
          string token = string.Format("-{0}-GET-/video.xml-", date);
    
          byte[] salt_binary = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(token));
          string salt_hex = BitConverter.ToString(salt_binary).Replace("-", "").ToLower();
          string salt = salt_hex.Substring(0, 20);
    
          HMACSHA1 hmac_sha1 = new HMACSHA1(Encoding.ASCII.GetBytes(PrivateKey));
          hmac_sha1.Initialize();
    
          byte[] private_key_binary = Encoding.ASCII.GetBytes(salt);
          byte[] passkey_binary = hmac_sha1.ComputeHash(private_key_binary, 0, private_key_binary.Length);
    
          string passkey = Convert.ToBase64String(passkey_binary).Trim();
        }
      }
    }
