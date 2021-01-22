        public class CryptographyProcessor
        {
            public string CreateSalt(int size)
            {
                //Generate a cryptographic random number.
                  RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                 byte[] buff = new byte[size];
                 rng.GetBytes(buff);
                 return Convert.ToBase64String(buff);
            }
 
    
              public string GenerateHash(string input, string salt)
              { 
                 byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
                 SHA256Managed sHA256ManagedString = new SHA256Managed();
                 byte[] hash = sHA256ManagedString.ComputeHash(bytes);
                 return Convert.ToBase64String(hash);
              }
              public bool AreEqual(string plainTextInput, string hashedInput, string salt)
              {
                   string newHashedPin = GenerateHash(plainTextInput, salt);
                   return newHashedPin.Equals(hashedInput); 
              }
         }
`
 
