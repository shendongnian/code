    public class SelfSignedCertificateValidator
    {
        private class CertificateAttributes
        {
            public string Subject { get; private set; }
            public string Issuer { get; private set; }
            public string Thumbprint { get; private set; }
            public CertificateAttributes(string subject, string issuer, string thumbprint)
            {
                Subject = subject;
                Issuer = issuer;                
                Thumbprint = thumbprint.Trim(
                    new char[] { '\u200e', '\u200f' } // strip any lrt and rlt markers from copy/paste
                    ); 
            }
            public bool IsMatch(X509Certificate cert)
            {
                bool subjectMatches = Subject.Replace(" ", "").Equals(cert.Subject.Replace(" ", ""), StringComparison.InvariantCulture);
                bool issuerMatches = Issuer.Replace(" ", "").Equals(cert.Issuer.Replace(" ", ""), StringComparison.InvariantCulture);
                bool thumbprintMatches = Thumbprint == String.Join(" ", cert.GetCertHash().Select(h => h.ToString("x2")));
                return subjectMatches && issuerMatches && thumbprintMatches; 
            }
        }
        private readonly List<CertificateAttributes> __knownSelfSignedCertificates = new List<CertificateAttributes> {
            new CertificateAttributes(  // can paste values from "view cert" dialog
                "CN = subject.company.int", 
                "CN = issuer.company.int", 
                "f6 23 16 3d 5a d8 e5 1e 13 58 85 0a 34 9f d6 d3 c8 23 a8 f4") 
        };       
        
        private static bool __createdSingleton = false;
        public SelfSignedCertificateValidator()
        {
            lock (this)
            {
                if (__createdSingleton)
                    throw new Exception("Only a single instance can be instanciated.");
                // Hook in validation of SSL server certificates.  
                ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertficate;
                __createdSingleton = true;
            }
        }
        /// <summary>
        /// Validates the SSL server certificate.
        /// </summary>
        /// <param name="sender">An object that contains state information for this
        /// validation.</param>
        /// <param name="cert">The certificate used to authenticate the remote party.</param>
        /// <param name="chain">The chain of certificate authorities associated with the
        /// remote certificate.</param>
        /// <param name="sslPolicyErrors">One or more errors associated with the remote
        /// certificate.</param>
        /// <returns>Returns a boolean value that determines whether the specified
        /// certificate is accepted for authentication; true to accept or false to
        /// reject.</returns>
        private bool ValidateServerCertficate(
            object sender,
            X509Certificate cert,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;   // Good certificate.
            Dbg.WriteLine("SSL certificate error: {0}", sslPolicyErrors);
            return __knownSelfSignedCertificates.Any(c => c.IsMatch(cert));            
        }
    }
