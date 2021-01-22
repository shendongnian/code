    System.Security.Cryptography.RSACryptoServiceProvider Provider =
                    new System.Security.Cryptography.RSACryptoServiceProvider();
    Provider.ImportParameters(your_rsa_key);
    byte[] encrypted = Provider.Encrypt(System.Text.Encoding.UTF8.GetBytes("Hello World!"), true);
    string decrypted = System.Text.Encoding.UTF8.GetString(Provider.Decrypt(encrypted, true));
