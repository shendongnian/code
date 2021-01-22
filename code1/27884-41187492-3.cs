     public bool ReadCertFromSignedFile(X509Certificate2 cert, string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && File.Exists(filename))
            {
                var cert509 = X509Certificate.CreateFromSignedFile(filename);
                cert = new X509Certificate2(cert509.GetRawCertData());
               
                return CheckSertificate(cert);
            }
            else
            { throw new Exception("Сертификат не заполнен"); }
        }
