    public class Crypt
    {
        public string Encrypt(string passtext, string passPhrase, string saltV, string hashstring, int Iterations, string initVect, int keysize)
        {
            string functionReturnValue = null;
            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = null;
            initVectorBytes = Encoding.ASCII.GetBytes(initVect);
            byte[] saltValueBytes = null;
            saltValueBytes = Encoding.ASCII.GetBytes(saltV);
            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = null;
            plainTextBytes = Encoding.UTF8.GetBytes(passtext);
            // First, we must create a password, from which the key will be derived.
			// This password will be generated from the specified passphrase and
			// salt value. The password will be created using the specified hash
			// algorithm. Password creation can be done in several iterations.
			PasswordDeriveBytes password = default(PasswordDeriveBytes);
            password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashstring, Iterations);
            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = null;
            keyBytes = password.GetBytes(keysize/8);
            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = default(RijndaelManaged);
            symmetricKey = new RijndaelManaged();
            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;
            // Generate encryptor from the existing key bytes and initialization
            // vector. Key size will be defined based on the number of the key
            // bytes.
            ICryptoTransform encryptor = default(ICryptoTransform);
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = default(MemoryStream);
            memoryStream = new MemoryStream();
            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = default(CryptoStream);
            cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            // Finish encrypting.
            cryptoStream.FlushFinalBlock();
            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = null;
            cipherTextBytes = memoryStream.ToArray();
            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();
            // Convert encrypted data into a base64-encoded string.
            string cipherText = null;
            cipherText = Convert.ToBase64String(cipherTextBytes);
            functionReturnValue = cipherText;
            return functionReturnValue;
        }
        public string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            string functionReturnValue = null;
            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
      
            
                byte[] initVectorBytes = null;
                initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = null;
                saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                // Convert our ciphertext into a byte array.
                byte[] cipherTextBytes = null;
                cipherTextBytes = Convert.FromBase64String(cipherText);
                // First, we must create a password, from which the key will be
                // derived. This password will be generated from the specified
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                PasswordDeriveBytes password = default(PasswordDeriveBytes);
                password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes = null;
                keyBytes = password.GetBytes(keySize / 8);
                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = default(RijndaelManaged);
                symmetricKey = new RijndaelManaged();
                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;
                // Generate decryptor from the existing key bytes and initialization
                // vector. Key size will be defined based on the number of the key
                // bytes.
                ICryptoTransform decryptor = default(ICryptoTransform);
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = default(MemoryStream);
                memoryStream = new MemoryStream(cipherTextBytes);
                // Define memory stream which will be used to hold encrypted data.
                CryptoStream cryptoStream = default(CryptoStream);
                cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                byte[] plainTextBytes = null;
                plainTextBytes = new byte[cipherTextBytes.Length + 1];
                // Start decrypting.
                int decryptedByteCount = 0;
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();
                // Convert decrypted data into a string.
                // Let us assume that the original plaintext string was UTF8-encoded.
                string plainText = null;
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                // Return decrypted string.
                functionReturnValue = plainText;
            
            
            return functionReturnValue;
        }
    }
