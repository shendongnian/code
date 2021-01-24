    string password = "password";
    using (Aes aes = Aes.Create())
            {
               //Encrypt the string
               byte[] encrypted = EncryptStringToBytes_Aes(password, aes.Key, aes.IV);
               //Decrypt the string
               string roundtrip = DecryptStringFromBytes_Aes(encrypted, aes.Key, aes.IV);
               //Convert the key, iv and encrypted message to base 64 string to get them in text
               Convert.ToBase64String(encrypted)
            }
