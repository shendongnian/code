    RSAParameters rsaParameters = default(RSAParameters);
    using (StreamWriter writer = new StreamWriter("rsa.key"))
    using (RSA rsa = RSA.Create())
    {
        rsa.ImportParameters(rsaParameters);
        writer.WriteLine("-----BEGIN RSA PRIVATE KEY-----");
        writer.WriteLine(
            Convert.ToBase64String(
                rsa.ExportRSAPrivateKey(),
                Base64FormattingOptions.InsertLineBreaks));
        writer.WriteLine("-----END RSA PRIVATE KEY-----");
    }
