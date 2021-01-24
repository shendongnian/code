                X509Certificate2 cert = null;
                var client = new TcpClient(host, 443);
                var certValidation = new RemoteCertificateValidationCallback(delegate (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors)
                {
                    //Accept every certificate, even if it's invalid
                    return true;
                });
                // Create an SSL stream and takeover client's stream
                using (var sslStream = new SslStream(client.GetStream(), true, certValidation))
                {
                    sslStream.AuthenticateAsClient(host);
                    var serverCertificate = sslStream.RemoteCertificate;
                    cert = new X509Certificate2(serverCertificate);
                    //Convert Raw Data to Base64String
                    var certBytes = cert.Export(X509ContentType.Cert);
                    var certAsString = Convert.ToBase64String(certBytes, Base64FormattingOptions.None);
                }
