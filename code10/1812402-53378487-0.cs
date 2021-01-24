    using (X509Chain ch = new X509Chain())
    {
        ch.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        return ch.Build(certificate);
    }
