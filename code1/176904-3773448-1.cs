X509Certificate cert = new X509Certificate("sslCert.txt");
X509CertificateCollection certColl = new X509CertificateCollection();
certColl.Add(cert);
CredentialCache credCache = new CredentialCache();
credCache.Add(new Uri(string.Concat(outputReport.reportURI)), "Basic", new NetworkCredential(NexConfig.User, NexConfig.Pass));
wr.AllowAutoRedirect = false;
wr.ClientCertificates = certColl;
wr.Credentials = credCache;
HttpWebResponse resp = (HttpWebResponse)wr.GetResponse();
