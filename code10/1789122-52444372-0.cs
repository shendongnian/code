        private static void CryptoTest()
        {
            byte[] serversPublicKey = GetPublicKey();
            // Create a new instance of RSACryptoServiceProvider.
            var RSA = new RSACryptoServiceProvider();
            var RSAKeyInfo = RSA.ExportParameters(includePrivateParameters: false);
            // Set RSAKeyInfo withthe provided public key. 
            RSAKeyInfo.Modulus = serversPublicKey;
            RSA.ImportParameters(RSAKeyInfo);
            // Generate New AES key
            var aes = new AesCryptoServiceProvider();
            aes.GenerateIV();
            aes.GenerateKey();
            byte[] sessionKey;
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    // Encrypt the aes key and iv
                    writer.Write(aes.Key);
                    writer.Write(":");
                    writer.Write(aes.IV);
                }
                sessionKey = RSA.Encrypt(stream.ToArray(), RSAEncryptionPadding.Pkcs1);
            }
            Console.WriteLine($"Encrypted Session Key (Base64): {Convert.ToBase64String(sessionKey)}");
            // Todo Step 7 send key to server
        }
