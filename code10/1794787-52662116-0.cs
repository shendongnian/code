     Uri uri = new Uri("http://ReportServer/Reports");
            WebClient client = new WebClient();
            //client.Credentials = CredentialCache.DefaultCredentials;
            client.Credentials = new NetworkCredential("username", "password");
            using (Stream data = client.OpenRead(uri))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    string result = sr.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
