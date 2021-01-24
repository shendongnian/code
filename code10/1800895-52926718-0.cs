     private bool VerifyCertificate(X509Certificate2 client)
        {
            X509Chain chain = new X509Chain();
            var stringCert = WebConfigurationManager.AppSettings["CACertificate"];
            var byteCert = Encoding.ASCII.GetBytes(stringCert);
            var authority = new X509Certificate2(byteCert);
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            
            chain.ChainPolicy.ExtraStore.Add(authority);
            // Do the preliminary validation.
            if (!chain.Build(client))
                return false;
            // This piece makes sure it actually matches your known root
            var valid = chain.ChainElements
                .Cast<X509ChainElement>()
                .Any(x => x.Certificate.Thumbprint == authority.Thumbprint);
            if (!valid)
                return false;
            return true;
        }
