    public static string Encrypt(this string stringToEncrypt, string key)
            {
                if (string.IsNullOrEmpty(stringToEncrypt))
                {
                    throw new ArgumentException("An empty string value cannot be encrypted.");
                }
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
                }
                System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
                cspp.KeyContainerName = key;
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
                rsa.PersistKeyInCsp = true;
                byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);
                return BitConverter.ToString(bytes);
            }
