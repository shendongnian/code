    private static RSAParameters GetRsaParameters(string rsaPrivateKey)
    {
        var byteArray = Encoding.ASCII.GetBytes(rsaPrivateKey);
        using (var ms = new MemoryStream(byteArray))
        {
            using (var sr = new StreamReader(ms))
            {
                var pemReader = new Org.BouncyCastle.Utilities.IO.Pem.PemReader(sr);
                var pem = pemReader.ReadPemObject();
                var privateKey = PrivateKeyFactory.CreateKey(pem.Content);
                return DotNetUtilities.ToRSAParameters(privateKey as RsaPrivateCrtKeyParameters);
            }
        }
    }
