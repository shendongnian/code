    private string podpisz(X509Certificate2 cert, string toSign)
    {
        string output = "";
        try
        {
            RSACryptoServiceProvider csp = null;
            csp = (RSACryptoServiceProvider)cert.PrivateKey;
            // Hash the data
            SHA256Managed sha256 = new SHA256Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = Encoding.Default.GetBytes(toSign);
            byte[] hash = sha256.ComputeHash(data);
            // Sign the hash
            byte[] wynBin = csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
            output = Convert.ToBase64String(wynBin);
        }
        catch (Exception)
        {
        }
        return output;
    }
