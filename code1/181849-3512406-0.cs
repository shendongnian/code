    public static string Sign(string method, string uuid, string data)
    {
        string merchantPrivateKey = File.ReadAllText("merchant_private_key.pem");
        byte[] der = opensslkey.DecodePkcs8PrivateKey(merchantPrivateKey);
        using (RSACryptoServiceProvider rsa = opensslkey.DecodePrivateKeyInfo(der))
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            // This will contain the data to sign
            byte[] dataToSign = Encoding.Default.GetBytes(method + uuid + data);
            byte[] signature = rsa.SignData(dataToSign, md5);
            return Convert.ToBase64String(signature);
        }
    }
