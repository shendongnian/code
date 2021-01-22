        void InitPhase()
    {
        // Override automatic validation of SSL server certificates.
        ServicePointManager.ServerCertificateValidationCallback =
               ValidateServerCertficate;
    }
    private static bool ValidateServerCertficate(
            object sender,
            X509Certificate cert,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            // Good certificate.
            return true;
        }
    
        log.DebugFormat("SSL certificate error: {0}", sslPolicyErrors);
    
        bool certMatch = false; // Assume failure
        byte[] certHash = cert.GetCertHash();
        if (certHash.Length == apiCertHash.Length)
        {
            certMatch = true; // Now assume success.
            for (int idx = 0; idx < certHash.Length; idx++)
            {
                if (certHash[idx] != apiCertHash[idx])
                {
                    certMatch = false; // No match
                    break;
                }
            }
        }
    
        // Return true => allow unauthenticated server,
        //        false => disallow unauthenticated server.
        return certMatch;
    }
