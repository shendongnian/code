    using (X509Chain ch = new X509Chain())
    {
        ch.ChainPolicy.RevocationMode = X509RevocationMode.Offline;
        ch.ChainPolicy.VerificationFlags =
            X509VerificationFlags.IgnoreEndRevocationUnknown |
            X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown |
            X509VerificationFlags.IgnoreRootRevocationUnknown;
        return ch.Build(certificate);
    }
