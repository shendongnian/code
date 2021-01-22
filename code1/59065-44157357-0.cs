    System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (
        object sender,
        X509Certificate cert,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;   //Is valid
        }
        //Add the mismatched certificate hashstring below. 
        //That way only that resource will be affected and not all certificates will be trusted.
        if (cert.GetCertHashString() == "99E92D8447AEF30483B1D7527812C9B7B3A915A7")
        {
            return true;
        }
    
        return false;
    };
