    using System;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    public class HttpWebRequestClientCertificateTest : ICertificatePolicy {
        public bool CheckValidationResult (ServicePoint sp, X509Certificate certificate,
                WebRequest request, int error)
        {
                return true; // server certificate's CA is not known to windows.
        }
        static void Main (string[] args)
        {
                string host = "https://localhost:1234/";
                if (args.Length > 0)
                        host = args[0];
                X509Certificate2 certificate = null;
                if (args.Length > 1) {
                        string password = null;
                        if (args.Length > 2)
                                password = args [2];
                        certificate = new X509Certificate2 (args[1], password);
                }
                ServicePointManager.CertificatePolicy = new HttpWebRequestClientCertificateTest ();
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create (host);
                if (certificate != null)
                        req.ClientCertificates.Add (certificate);
                WebResponse resp = req.GetResponse ();
                Stream stream = resp.GetResponseStream ();
                StreamReader sr = new StreamReader (stream, Encoding.UTF8);
                Console.WriteLine (sr.ReadToEnd ());
        }
}
