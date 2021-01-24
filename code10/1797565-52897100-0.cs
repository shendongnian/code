    ...
    try
    {
        // Viene calcolata la firma del file (in formato PKCS7)
        signedCms.ComputeSignature(signer,false);
    }
    catch (CryptographicException CEx)
    {
        try
        {
            // Try re-importing the private key into a better CSP:
            using (RSA tmpRsa = RSA.Create())
            {
                tmpRsa.ImportParameters(cert.GetRSAPrivateKey().ExportParameters(true));
                using (X509Certificate2 tmpCertNoKey = new X509Certificate2(cert.RawData))
                using (X509Certificate2 tmpCert = tmpCertNoKey.CopyWithPrivateKey(tmpRsa))
                {
                    signer.Certificate = tmpCert;
                    signedCms.ComputeSignature(signer,false);
                }
            }
        }
        catch (CryptographicException)
        {
            // This is the original exception, not the inner one.
            RisFirma = "Errore: " + CEx.Message + " Stack: " + CEx.StackTrace;
            return RisFirma;
        }
    }
