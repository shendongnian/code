    //only add the certificate validation if we are using a https url
    if (url.StartsWith("https:"))
    {
        ServicePointManager.ServerCertificateValidationCallback += 
        new RemoteCertificateValidationCallback(HttpHelper.ValidateRemoteCertificate);
    }
    //then i create a HttpWebRequest with the URL and call request.GetResponse()...
    public static class HttpHelper
    {
        public static bool ValidateRemoteCertificate(object sender, 
            X509Certificate certificate, X509Chain chain, 
            SslPolicyErrors policyErrors)
        {
            return true;
        }
    }
