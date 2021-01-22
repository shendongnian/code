            private byte[] UploadValues(string method, NameValueCollection data)
            {
                var client = new WebClient();
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
                        ServerCertificateValidation;
                    returnrclient.UploadValues(uri, method, parameters);
                }
                finally
                {
                    ServicePointManager.ServerCertificateValidationCallback -=
                        ServerCertificateValidation;
                }
            }
            private bool ServerCertificateValidation(object sender,
                X509Certificate certificate, X509Chain chain,
                SslPolicyErrors sslPolicyErrors)
            {
                var request = sender as HttpWebRequest;
                if (request != null && request.Address.Host.Equals(
                    this.uri.Host, StringComparison.OrdinalIgnoreCase))
                    return true;
                return false;
            }
