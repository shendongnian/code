            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                string name = certificate.Subject;
                
                DateTime expirationDate = DateTime.Parse(certificate.GetExpirationDateString());
                
                if (sslPolicyErrors == SslPolicyErrors.None || (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch && name.EndsWith(".acceptabledomain.com") && expirationDate > DateTime.Now))
                {
                    return true;
                }
                return false;
            };
