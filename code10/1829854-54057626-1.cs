    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureKestrel((context, options) =>
                {
                    options.Listen(IPAddress.Loopback, 5022);
                    options.Listen(IPAddress.Loopback, 5023, listenOptions =>
                    {
                        listenOptions.UseHttps((httpsOptions) =>
                        {
                            var certFileName = "server_cert.pfx";
                            var contentRoot = context.HostingEnvironment.ContentRootPath;
                            X509Certificate2 serverCert;
                            var path = Path.Combine(contentRoot, certFileName);
                            serverCert = new X509Certificate2(path, "<server cert password>");
                            httpsOptions.ServerCertificate = serverCert;
                            // this is what will make the browser display the client certificate dialog
                            httpsOptions.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
                            httpsOptions.CheckCertificateRevocation = false;
                            httpsOptions.ClientCertificateValidation = (certificate2, validationChain, policyErrors) =>
                            {
                                // this is for testing non production certificates, do not use these settings in production
                                validationChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                                validationChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                                validationChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                                validationChain.ChainPolicy.VerificationTime = DateTime.Now;
                                validationChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
                                validationChain.ChainPolicy.ExtraStore.Add(serverCert);
                                
                                var valid = validationChain.Build(certificate2);
                                if (!valid)
                                    return false;
                                // only trust certs that are signed by our CA cert
                                valid = validationChain.ChainElements
                                    .Cast<X509ChainElement>()
                                    .Any(x => x.Certificate.Thumbprint == serverCert.Thumbprint);
                                return valid;
                            };
                        });
                    });
                });
    }
