public static class KeyVaultEncryptorDecryptor
{
    public static string KeyDecryptText(this string textToDecrypt , KeyVaultClient keyVaultClient, string keyidentifier)
    {
        var kv = keyVaultClient;
        try
        {
            var key = kv.GetKeyAsync(keyidentifier).Result;
            var publicKey = Convert.ToBase64String(key.Key.N);
            using var rsa = new RSACryptoServiceProvider();
            var p = new RSAParameters() {
                Modulus = key.Key.N, Exponent = key.Key.E
            };
            rsa.ImportParameters(p);
            var encryptedTextNew = Convert.FromBase64String(textToDecrypt);
            var decryptedData = kv.DecryptAsync(key.KeyIdentifier.Identifier.ToString(), JsonWebKeyEncryptionAlgorithm.RSAOAEP, encryptedTextNew).GetAwaiter().GetResult();
            var decryptedText = Encoding.Unicode.GetString(decryptedData.Result);
            return decryptedText;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return default;
        }
    }
    public static string KeyEncryptText(this string textToEncrypt , KeyVaultClient keyVaultClient, string keyidentifier)
    {
        var kv = keyVaultClient;
        try
        {
            var key = kv.GetKeyAsync(keyidentifier).GetAwaiter().GetResult();
            var publicKey = Convert.ToBase64String(key.Key.N);
            using var rsa = new RSACryptoServiceProvider();
            var p = new RSAParameters() {
                Modulus = key.Key.N, Exponent = key.Key.E
            };
            rsa.ImportParameters(p);
            var byteData = Encoding.Unicode.GetBytes(textToEncrypt);
            var encryptedText = rsa.Encrypt(byteData, true);
            string encText = Convert.ToBase64String(encryptedText);
            return encText;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return default;
        }
    }
}
