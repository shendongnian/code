        private static TwoLeggedApi oauth2TwoLegged;
        private static dynamic twoLeggedCredentials;
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
         // Initialize the 2-legged OAuth 2.0 client, and optionally set specific scopes.
        private static void initializeOAuth()
        {
            // You must provide at least one valid scope
            Scope[] scopes = new Scope[] { Scope.DataRead, Scope.DataWrite, Scope.BucketCreate, Scope.BucketRead };
            oauth2TwoLegged = new TwoLeggedApi();
            twoLeggedCredentials = oauth2TwoLegged.Authenticate(FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, scopes);
            objectsApi.Configuration.AccessToken = twoLeggedCredentials.access_token;
        }
        private static void uploadFileToBucket(string bucketKey, string filePath)
        {
            Console.WriteLine("*****Start uploading file to the OSS");
            string path = filePath;
            //File Total size
            var info = new System.IO.FileInfo(path);
            long fileSize = info.Length;
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                string sessionId = RandomString(12);
                Console.WriteLine(string.Format("sessionId: {0}", sessionId));
                long contentLength = fileSize;
                string content_range = "bytes 0-" + (contentLength - 1) + "/" + contentLength;
                Console.WriteLine("Uploading range： " + content_range);
                byte[] buffer = new byte[contentLength];
                MemoryStream memoryStream = new MemoryStream(buffer);
                int nb = fileStream.Read(buffer, 0, (int)contentLength);
                memoryStream.Write(buffer, 0, nb);
                memoryStream.Position = 0;
                dynamic response = objectsApi.UploadChunk(bucketKey, info.Name, (int)contentLength, content_range,
                    sessionId, memoryStream);
                Console.WriteLine(response);
            }
        }
        static void Main(string[] args)
        {
            initializeOAuth();
            uploadFileToBucket(BUCKET_KEY, FILE_PATH);
        }
