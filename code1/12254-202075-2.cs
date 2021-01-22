    var provider = new System.Security.Cryptography.RSACryptoServiceProvider();
    provider.ImportParameters(your_rsa_key);
    var encryptedBytes = provider.Encrypt(
        System.Text.Encoding.UTF8.GetBytes("Hello World!"), true);
    string decryptedTest = System.Text.Encoding.UTF8.GetString(
        provider.Decrypt(encryptedBytes, true));
