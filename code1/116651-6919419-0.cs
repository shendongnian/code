            string apiKey = "<your api key>";
            var client = new PasteBinClient(apiKey);
            // Optional; will publish as a guest if not logged in
            client.Login(userName, password);
            var entry = new PasteBinEntry
                {
                    Title = "PasteBin client test",
                    Text = "Console.WriteLine(\"Hello PasteBin\");",
                    Expiration = PasteBinExpiration.OneDay,
                    Private = true,
                    Format = "csharp"
                };
            string pasteUrl = client.Paste(entry);
            Console.WriteLine("Your paste is published at this URL: " + pasteUrl);
