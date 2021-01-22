    public string GenerateAPassKey(string passphrase)
        {
            // Pass Phrase can be any string
            string passPhrase = passphrase;
            // Salt Value can be any string(for simplicity use the same value as used for the pass phrase)
            string saltValue = passphrase;
            // Hash Algorithm can be "SHA1 or MD5"
            string hashAlgorithm = "SHA1";
            // Password Iterations can be any number
            int passwordIterations = 2;
            // Key Size can be 128,192 or 256
            int keySize = 256;
            // Convert Salt passphrase string to a Byte Array
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            // Using System.Security.Cryptography.PasswordDeriveBytes to create the Key
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            //When creating a Key Byte array from the base64 string the Key must have 32 dimensions.
            byte[] Key = pdb.GetBytes(keySize / 11);
            String KeyString = Convert.ToBase64String(Key);
            return KeyString;
        }
     //Save the keystring some place like your database and use it to decrypt and encrypt
    //any text string or text file etc. Make sure you dont lose it though.
     private static string Encrypt(string plainStr, string KeyString)        
        {            
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.ECB;
            aesEncryption.Padding = PaddingMode.ISO10126;
            byte[] KeyInBytes = Encoding.UTF8.GetBytes(KeyString);
            aesEncryption.Key = KeyInBytes;
            byte[] plainText = ASCIIEncoding.UTF8.GetBytes(plainStr);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }
     private static string Decrypt(string encryptedText, string KeyString) 
        {
            RijndaelManaged aesEncryption = new RijndaelManaged(); 
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128; 
            aesEncryption.Mode = CipherMode.ECB;
            aesEncryption.Padding = PaddingMode.ISO10126;
            byte[] KeyInBytes = Encoding.UTF8.GetBytes(KeyString);
            aesEncryption.Key = KeyInBytes;
            ICryptoTransform decrypto = aesEncryption.CreateDecryptor(); 
            byte[] encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length); 
            return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)); 
        }
     String KeyString = GenerateAPassKey("PassKey");
     String EncryptedPassword = Encrypt("25Characterlengthpassword!", KeyString);
     String DecryptedPassword = Decrypt(EncryptedPassword, KeyString);
