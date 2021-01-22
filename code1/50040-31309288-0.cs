    public static bool RemoteServerCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            // if got an cert auth error
            if (sslPolicyErrors != SslPolicyErrors.RemoteCertificateNameMismatch) return false;
            const string sertFileName = "smpthost.cer";
            // check if cert file exists
            if (File.Exists(sertFileName))
            {
                var actualCertificate = X509Certificate.CreateFromCertFile(sertFileName);
                return certificate.Equals(actualCertificate);
            }
            
            // export and check if cert not exists
            using (var file = File.Create(sertFileName))
            {
                var cert = certificate.Export(X509ContentType.Cert);
                file.Write(cert, 0, cert.Length);
            }
            var createdCertificate = X509Certificate.CreateFromCertFile(sertFileName);
            return certificate.Equals(createdCertificate);
        }
