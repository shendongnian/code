    private static byte[] s_issuingCABytes = { ... };
    handler.ServerCertificateCustomValidationCallback +=
        (message, certificate, chain, errors) =>
        {
            const SslPolicyErrors Mask =
    #if CA_IS_TRUSTED
                ~SslPolicyErrors.None;
    #else
                ~SslPolicyErrors.RemoteCertificateChainErrors;
    #endif
            // If a cert is not present, or it didn't match the host.
            // (And if the CA should have been root trusted anyways, also checks that)
            if ((errors & Mask) != SslPolicyErrors.None)
            {
                return false;
            }
            foreach (X509ChainElement element in chain.ChainElements)
            {
                if (element.Certificate.RawData.SequenceEqual(s_issuingCABytes))
                {
                    // The expected certificate was found, huzzah!
                    return true;
                }
            }
            // The expected cert was not in the chain.
            return false;
        };
