     public bool ReadCertFromSignedFile(X509Certificate2 cert, string filename)
        {
            if (!string.IsNullOrWhiteSpace(filename) && File.Exists(filename))
            {
                var cert509 = X509Certificate.CreateFromSignedFile(filename);
                cert.Import(cert509.GetRawCertData());
