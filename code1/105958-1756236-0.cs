    public static string CalculateSHA1(string text, Encoding enc)
    {
        byte[] buffer = enc.GetBytes(text);
        SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
        return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
    }
