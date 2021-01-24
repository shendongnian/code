    ServicePointManager.ServerCertificateValidationCallback += (object o, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;
        }
        else if (cert is X509Certificate2 cert2)
        {
            return cert2.Thumbprint == CertThumbprint;
        }
        return false;
    };
