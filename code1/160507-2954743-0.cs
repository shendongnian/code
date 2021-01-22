                Byte[] plainData = encoding.GetBytes(plainText);
                Byte[] encryptedData;
                Byte[] decryptedData;
                using (RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider())
                {
                    RSAParameters rsap1 = rsa1.ExportParameters(false);
                    using (RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider())
                    {
                        rsa2.ImportParameters(rsap1);
                        encryptedData = rsa2.Encrypt(plainData, false);
                    }
                    decryptedData = rsa1.Decrypt(encryptedData, false);
                }
                decryptedText = encoding.GetString(decryptedData, 0, decryptedData.Length);
