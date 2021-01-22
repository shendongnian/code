        public static bool ServicePointManager_ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool allowCertificate = true;
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                Console.WriteLine("Accepting the certificate with errors:");
                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    Console.WriteLine("\tThe certificate subject {0} does not match.", certificate.Subject);
                }
                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    Console.WriteLine("\tThe certificate chain has the following errors:");
                    foreach (X509ChainStatus chainStatus in chain.ChainStatus)
                    {
                        Console.WriteLine("\t\t{0}", chainStatus.StatusInformation);
                        if (chainStatus.Status == X509ChainStatusFlags.Revoked)
                        {
                            allowCertificate = false;
                        }
                    }
                }
                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
                {
                    Console.WriteLine("No certificate available.");
                    allowCertificate = false;
                }
                Console.WriteLine();
            }
            return allowCertificate;
        }
