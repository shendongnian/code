    using System;
    using System.Net;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml;
    
    public class GmailFeed
    {
        private class IgnoreBadCerts : ICertificatePolicy
        {
            public bool CheckValidationResult (ServicePoint sp, 
                                               X509Certificate certificate, 
                                               WebRequest request, 
                                               int error)
            {
                return true;
            }
     
    
        }
        
        public static void Main(string[] argv)
        {
            if(argv.Length != 2)
            {
                Console.Error.WriteLine("Usage: GmailFeed username password");
                Environment.ExitCode = 1;
                return;
            }
            ServicePointManager.CertificatePolicy = new IgnoreBadCerts();
            
            NetworkCredential cred = new NetworkCredential();
            cred.UserName = argv[0];
            cred.Password = argv[1];
            
            WebRequest req = WebRequest.Create("https://gmail.google.com/gmail/feed/atom");
            req.Credentials = cred;
            Stream resp = req.GetResponse().GetResponseStream();
    
            XmlReader reader = XmlReader.Create(resp);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
        }
    }
