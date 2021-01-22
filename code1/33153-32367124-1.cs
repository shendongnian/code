        private static bool ValidateServerCertficate(
            object sender,
            X509Certificate cert,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                // Good certificate.
                return true;
            }
            Common.Helpers.Logger.Log.Error(string.Format("SSL certificate error: {0}", sslPolicyErrors));
            try
            {
                using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
                {
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(new X509Certificate2(cert));
                    store.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.Helpers.Logger.Log.Error(string.Format("SSL certificate add Error: {0}", ex.Message));
            }
            return false;
        }
