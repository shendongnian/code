    public string GenerateAPassKey(string passphrase)
        {
            // Pass Phrase can be any string
            string passPhrase = passphrase;
            // Salt Value can be any string(for simplicity use the same value as used for the pass phrase)
            string saltValue = passphrase;
            // Has Algorithm can be "SHA1 or MD5"
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
