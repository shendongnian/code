    public static string Decrypt(this string stringToDecrypt, string key)
            {
                string result = null;
                if (string.IsNullOrEmpty(stringToDecrypt))
                {
                    throw new ArgumentException("An empty string value cannot be encrypted.");
                }
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
                }
                try
                {
                    System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
                    cspp.KeyContainerName = key;
                    System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
                    rsa.PersistKeyInCsp = true;
                    string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
                    byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));
                    byte[] bytes = rsa.Decrypt(decryptByteArray, true);
                    result = System.Text.UTF8Encoding.UTF8.GetString(bytes);
                }
                finally
                {
                    // no need for further processing
                }
                return result;
            }
