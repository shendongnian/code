         // Client for requests
        private DriveService client;
        
        // Class constructor
        public GoogleDrive(string account)
        {
            UserCredential credential;
            Login = account;
            
            // Load Web Secret file
            using (var stream =
                new FileStream(System.Web.HttpContext.Current.Server.MapPath($"~/Resources/client_secret_{account}.json"), FileMode.Open, FileAccess.Read))
            {
                // Path to token folder 
                string credPath = System.Web.HttpContext.Current.Server.MapPath(Path.Combine("~/Resources/driveApiCredentials", "drive-credentials.json"));
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    account,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                //Console.WriteLine("Credential file saved to folder: " + credPath);
            }
            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = account,
            });
            client =  service;
        }
