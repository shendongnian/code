    private static bool certificateValidator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
    {
        return true;
    }
    using (Pop3Client client = new Pop3Client())
    {
        client.Connect("your_hostname", 995, true, 3000, 3000, certificateValidator);
    }
