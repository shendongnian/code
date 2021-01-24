            services.AddHttpClient("myName").ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                Credentials = new CredentialCache { 
                    {
                        new Uri("url"), "NTLM", new NetworkCredential("username", "password", "domain")
                    }
                }
            });
