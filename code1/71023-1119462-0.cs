    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AlwaysAccept);
    
    //... somewhere AlwaysAccept is defined as:
    
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    
    public bool AlwaysAccept(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
