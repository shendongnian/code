    AndroidClientHandler clientHandler = new AndroidClientHandler();
    Java.Security.Cert.X509Certificate cert = null;
    try
    {
        CertificateFactory factory = CertificateFactory.GetInstance("X.509");
        using (var stream = Application.Context.Assets.Open("MyCert.pfx"))
        {
            cert = (Java.Security.Cert.X509Certificate)factory.GenerateCertificate(stream);
        }
        } catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
        if (clientHandler.TrustedCerts != null)
        {
            clientHandler.TrustedCerts.Add(cert);
        }
        else
        {
            clientHandler.TrustedCerts = new List<Certificate>();
            clientHandler.TrustedCerts.Add(cert);
        }
        HttpClient client = new HttpClient(clientHandler);
