            var service = new SafebrowsingService(new BaseClientService.Initializer
            {
                ApplicationName = "dotnet-client",
                ApiKey = "API-KEY"
            });
            var request = service.ThreatMatches.Find(new FindThreatMatchesRequest()
            {
                Client = new ClientInfo
                {
                    ClientId = "Dotnet-client",
                    ClientVersion = "1.5.2"
                },
                ThreatInfo = new ThreatInfo()
                {
                    ThreatTypes = new List<string> { "Malware" },
                    PlatformTypes = new List<string> { "Windows" },
                    ThreatEntryTypes = new List<string> { "URL" },
                    ThreatEntries = new List<ThreatEntry>
                    {
                        new ThreatEntry
                        {
                            Url = "google.com"
                        }
                    }
                }
            });
            var response = await request.ExecuteAsync();
