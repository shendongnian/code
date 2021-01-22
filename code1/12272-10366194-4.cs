    /*
     * This work (Modern Encryption of a String C#, by James Tuley), 
     * identified by James Tuley, is free of known copyright restrictions.
     * https://gist.github.com/4336842
     * http://creativecommons.org/publicdomain/mark/1.0/ 
     */
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Encryption
    {
        public static class AESThenHMAC
        {
            private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();
    
            public static readonly int BlockBitSize = 128;
            public static readonly int KeyBitSize = 256;
    
            public static readonly int SaltBitSize = 64;
            public static readonly int MinPasswordLength = 12;
    
            /// <summary>
            /// Simple Encryption(AES) then Authentication (HMAC) for a UTF8 Message.
            /// </summary>
            /// <param name="secretMessage">The secret message.</param>
            /// <param name="cryptKey">The crypt key.</param>
            /// <param name="authKey">The auth key.</param>
            /// <param name="nonSecretPayload">(Optional) Non-Secret Payload.</param>
            /// <returns>Encrypted Message</returns>
            /// <remarks>
            /// Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Blocksize +  HMac-Tag(32)) * 1.33 Base64
            /// </remarks>
            public static string SimpleEncrypt(string secretMessage, byte[] cryptKey, byte[] authKey, byte[] nonSecretPayload = null)
            {
                //User Error Checks
                if (cryptKey == null || cryptKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("Key needs to be {0} bit!", KeyBitSize), "cryptKey");
    
                if (authKey == null || authKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("Key needs to be {0} bit!", KeyBitSize), "authKey");
    
                if (string.IsNullOrEmpty(secretMessage))
                    throw new ArgumentException("Secret Message Required!", "secretMessage");
    
                //non-secret payload optional
                nonSecretPayload = nonSecretPayload ?? new byte[] { };
    
                byte[] cipherText;
                byte[] iv;
    
                using (var aes = new AesManaged
                {
                    KeySize = KeyBitSize,
                    BlockSize = BlockBitSize,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
    
                    //Use random IV
                    aes.GenerateIV();
                    iv = aes.IV;
    
                    using (var encrypter = aes.CreateEncryptor(cryptKey, iv))
                    using (var cipherStream = new MemoryStream())
                    {
                        using (var tCryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                        using (var tBinaryWriter = new BinaryWriter(tCryptoStream))
                        {
                            //Encrypt Data
                            tBinaryWriter.Write(Encoding.UTF8.GetBytes(secretMessage));
                        }
    
                        cipherText = cipherStream.ToArray();
                    }
    
                }
    
                //Assemble encrypted message and add authentication
                using (var hmac = new HMACSHA256(authKey))
                using (var encryptedStream = new MemoryStream())
                {
                    using (var binaryWriter = new BinaryWriter(encryptedStream))
                    {
                        //Prepend non-secret payload if any
                        binaryWriter.Write(nonSecretPayload);
                        //Prepend IV
                        binaryWriter.Write(iv);
                        //Write Ciphertext
                        binaryWriter.Write(cipherText);
                        binaryWriter.Flush();
    
                        //Authenticate all data
                        var tag = hmac.ComputeHash(encryptedStream.ToArray());
                        //Postpend tag
                        binaryWriter.Write(tag);
                    }
                    return Convert.ToBase64String(encryptedStream.ToArray());
                }
    
            }
    
    
            /// <summary>
            /// Simple Authentication (HMAC) then Decryption (AES) for a secrets UTF8 Message.
            /// </summary>
            /// <param name="encryptedMessage">The encrypted message.</param>
            /// <param name="cryptKey">The crypt key.</param>
            /// <param name="authKey">The auth key.</param>
            /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
            /// <returns>Decrypted Message</returns>
            public static string SimpleDecrypt(string encryptedMessage, byte[] cryptKey, byte[] authKey, int nonSecretPayloadLength = 0)
            {
    
                //Basic Usage Error Checks
                if (cryptKey == null || cryptKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("CryptKey needs to be {0} bit!", KeyBitSize), "cryptKey");
    
                if (authKey == null || authKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("AuthKey needs to be {0} bit!", KeyBitSize), "authKey");
    
                if (string.IsNullOrWhiteSpace(encryptedMessage))
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");
    
                var message = Convert.FromBase64String(encryptedMessage);
                using (var hmac = new HMACSHA256(authKey))
                {
                    var sentTag = new byte[hmac.HashSize / 8];
                    //Calculate Tag
                    var calcTag = hmac.ComputeHash(message, 0, message.Length - sentTag.Length);
                    var ivLength = (BlockBitSize / 8);
    
                    //if message length is to small just return null
                    if (encryptedMessage.Length < sentTag.Length + nonSecretPayloadLength + ivLength)
                        return null;
    
                    //Grab Sent Tag
                    Array.Copy(message, message.Length - sentTag.Length, sentTag, 0, sentTag.Length);
    
                    //Compare Tag
                    var auth = true;
                    for (var i = 0; i < sentTag.Length; i++)
                        auth = auth && sentTag[i] == calcTag[i];
    
                    //if message doesn't authenticate return null
                    if (!auth)
                        return null;
    
                    using (var aes = new AesManaged
                    {
                        KeySize = KeyBitSize,
                        BlockSize = BlockBitSize,
                        Mode = CipherMode.CBC,
                        Padding = PaddingMode.PKCS7
                    })
                    {
    
                        //Grab IV from message
                        var iv = new byte[ivLength];
                        Array.Copy(message, nonSecretPayloadLength, iv, 0, iv.Length);
    
                        using (var decrypter = aes.CreateDecryptor(cryptKey, iv))
                        using (var plainTextStream = new MemoryStream())
                        {
                            using (var decrypterStream = new CryptoStream(plainTextStream, decrypter, CryptoStreamMode.Write))
                            using (var binaryWriter = new BinaryWriter(decrypterStream))
                            {
                                //Decrypt Cipher Text from Message
                                binaryWriter.Write(
                                    message,
                                    nonSecretPayloadLength + iv.Length,
                                    message.Length - nonSecretPayloadLength - iv.Length - sentTag.Length
                                );
                            }
                            //Return Plain Text
                            return Encoding.UTF8.GetString(plainTextStream.ToArray());
                        }
                    }
                }
            }
    
            /// <summary>
            /// Simple Encryption then Authentication of a UTF8 message
            /// using Keys derived from a Password
            /// </summary>
            /// <param name="secretMesage">The secret mesage.</param>
            /// <param name="password">The password.</param>
            /// <returns>Encrypted Message</returns>
            /// <remarks>Significantly less secure than using random binary keys.
            ///  Adds additional non secret payload for key generation parameters. </remarks>
            public static string SimpleEncryptWithPassword(string secretMesage, string password)
            {
                //User Error Checks
                if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                    throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");
    
                if (string.IsNullOrEmpty(secretMesage))
                    throw new ArgumentException("Secret Message Required!", "secretMesage");
    
                //iterations are not secret, nor does it need to change randomly
                //I'm just using random data because i prefer the non-secret payload looking
                //like random data
                var iters = new byte[8];
                Random.GetBytes(iters);
                var m = Math.Abs(BitConverter.ToInt32(iters, 0)) % 10;
                var a = Math.Abs(BitConverter.ToInt32(iters, 4)) % 10000;
                var iterations = 1000 * m + a + 5000;
    
                //Use Random Salt to prevent pre-generated weak password attacks.
                using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize / 8, iterations))
                {
                    var salt = generator.Salt;
    
                    //Generate Keys
                    var cryptKey = generator.GetBytes(KeyBitSize / 8);
                    var authKey = generator.GetBytes(KeyBitSize / 8);
    
                    //Create Non Secret Payload
                    var payload = new byte[salt.Length + iters.Length];
                    Array.Copy(salt, payload, salt.Length);
                    Array.Copy(iters, 0, payload, salt.Length, iters.Length);
    
                    return SimpleEncrypt(secretMesage, cryptKey, authKey, payload);
                }
            }
    
            /// <summary>
            /// Simple Authentication (HMAC) and then Descryption (AES) of a UTF8 Message
            /// using keys derived from a password.
            /// </summary>
            /// <param name="encryptedMessage">The encrypted message.</param>
            /// <param name="password">The password.</param>
            /// <returns>Decrypted Message</returns>
            /// <remarks>Significantly less secure than using random binary keys. </remarks>
            public static string SimpleDecryptWithPassword(string encryptedMessage, string password)
            {
                //User Error Checks
                if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                    throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");
    
                if (string.IsNullOrWhiteSpace(encryptedMessage))
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");
    
                var salt = new byte[SaltBitSize / 8];
                var iters = new byte[8];
    
                var message = Convert.FromBase64String(encryptedMessage);
    
                //Grab Salt And Iterations from Non-Secret Payload
                Array.Copy(message, salt, salt.Length);
                Array.Copy(message, salt.Length, iters, 0, iters.Length);
                var m = Math.Abs(BitConverter.ToInt32(iters, 0)) % 10;
                var a = Math.Abs(BitConverter.ToInt32(iters, 4)) % 10000;
                var iterations = 1000 * m + a + 5000;
    
                //Generate keys
                using (var generator = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var cryptKey = generator.GetBytes(KeyBitSize / 8);
                    var authKey = generator.GetBytes(KeyBitSize / 8);
    
                    return SimpleDecrypt(encryptedMessage, cryptKey, authKey, salt.Length + iters.Length);
                }
            }
    
        }
    }
