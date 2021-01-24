        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                 .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 443, listenOptions =>
                    {
                        listenOptions.UseHttps(GetHttpsCertificateFromStore());
                        listenOptions.NoDelay = true;
                    });
                })
                .Build();
        }
        private static X509Certificate2 GetHttpsCertificateFromStore()
        {
            using (var store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                var certCollection = store.Certificates;
                var currentCerts = certCollection.Find(X509FindType.FindBySubjectDistinguishedName, "CN=[your common name here]", false);
                if (currentCerts.Count == 0)
                {
                    throw new Exception("Https certificate is not found.");
                }
                return currentCerts[0];
            }
        }
