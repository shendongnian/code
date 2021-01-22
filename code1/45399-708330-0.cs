    public static void ConnectSSL()
    {
    
        WebRequest request = WebRequest.Create("https://" + sslServerHost + ":" + sslServerPort);
        request.Proxy = null;
        request.Credentials = CredentialCache.DefaultCredentials;
    
       //allows for validation of SSL certificates 
        
        ServicePointManager.ServerCertificateValidationCallback += new  System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);
        
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
    
    }
    
    //for testing purpose only, accept any dodgy certificate... 
    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
              return true; 
    }
