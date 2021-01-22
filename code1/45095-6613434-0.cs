                //Trust all certificates
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    ((sender, certificate, chain, sslPolicyErrors) => true);
                // trust sender
                System.Net.ServicePointManager.ServerCertificateValidationCallback
                    = ((sender, cert, chain, errors) => cert.Subject.Contains("YourServerName"));
                // validate cert by calling a function
                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
        // callback used to validate the certificate in an SSL conversation
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            bool result = false;
            if (cert.Subject.ToUpper().Contains("YourServerName"))
            {
                result = true;
            }
            return result;
        }
