    public static void Main() 
    {
        Console.Write(GenerateCsr(GenerateRsaKeyPair()));
    }
    /// <summary>
    /// Generates a 2048 bit RSA key pair.
    /// </summary>
    /// <returns>The key container</returns>
    public static CryptoKey GenerateRsaKeyPair()
    {
        using(var rsa = new RSA())
        {
            rsa.GenerateKeys(2048, 0x10021, null, null);
            return new CryptoKey(rsa);
        }
    }
    /// <summary>
    /// Generates a CSR file content using to the hard-coded details and the given key.
    /// </summary>
    /// /// <param name="key">RSA key to be used</param>
    /// <returns>The CSR file content</returns>
    public static string GenerateCsr(CryptoKey key)
    {
        using (var subject = new X509Name
        {
            SerialNumber = "1234567890",
            Organization = "My Company"
            // Add more details here...
        })
        {
            using (var req = new X509Request(0, subject, key))
            {
                return req.PEM;
            }
        }
    }
