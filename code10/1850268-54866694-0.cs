    public static string PublicKey(string certSubject)
            {
                var my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                my.Open(OpenFlags.ReadOnly);
                RSACryptoServiceProvider csp = null;
                byte[] publicKeyByte = null;
                foreach (var cert in my.Certificates)
                {
                    if (cert.Subject.Contains(certSubject))
                    {
                        csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
                        publicKeyByte = cert.PublicKey.EncodedKeyValue.RawData;
                    }
                }
                if (csp == null)
                {
                    throw new Exception("No valid cert was found");
                }
                var publicKey = new StringBuilder();
                publicKey.AppendLine("-----BEGIN PUBLIC KEY-----");
                publicKey.AppendLine(Convert.ToBase64String(publicKeyByte, Base64FormattingOptions.InsertLineBreaks));
                publicKey.AppendLine("-----END PUBLIC KEY-----");
                return publicKey.ToString();
            }
