    public static void Main(string[] args)
    {
        GetCertificate("https://www.facebook.com", "");
    }
    /// <summary>
    /// Get and write certificate from URL into file in path
    /// </summary>
    /// <param name="_URL">URL of website with certficate</param>
    /// <param name="_path">Path where you want to store certificate</param>
    private static void GetCertificate(string url, string path)
    {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = false;
            request.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
            Console.ReadLine();
    }
    private static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        foreach (var cert in chain.ChainElements)
        {
            Console.WriteLine(cert.Certificate.FriendlyName);
            Console.WriteLine(ExportToPem(cert.Certificate));
        }
        return true;
    }
    /// <summary>
    /// Export a certificate to a PEM format string
    /// </summary>
    /// <param name="_cert">The certificate to export</param>
    /// <returns>A PEM encoded string</returns>
    public static string ExportToPem(X509Certificate2 cert)
    {
        StringBuilder strBuilder = new StringBuilder();
        try
        {
            strBuilder.AppendLine("-----BEGIN CERTIFICATE-----");
            strBuilder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            strBuilder.AppendLine("-----END CERTIFICATE-----");
        }
        catch (Exception)
        {
        }
        return strBuilder.ToString();
    }
