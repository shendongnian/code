            try
            {
                // Create the service using the client credentials.
             var json=   HttpContext.Current.Server.MapPath("~/credentials.json");
                UserCredential credential;
                using (var stream = new FileStream(json, FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { DriveService.Scope.Drive },
                        "user", CancellationToken.None, new FileDataStore("Audio.files"));
                };
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "YourAppName"
                });
                var uploadFilepath = HttpContext.Current.Server.MapPath("~/Content/filename.flac");
                var uploadStream = new System.IO.FileStream(uploadFilepath,
                                                            System.IO.FileMode.Open,
                                                            System.IO.FileAccess.Read);
                // Get the media upload request object.
                var insertRequest = service.Files.Create(
                      new Google.Apis.Drive.v3.Data.File
                      {
                          Name = "Filename.flac",
                      },
                      uploadStream,
                      "audio/flac");
                var task = insertRequest.UploadAsync();
                await task.ContinueWith(t =>
                 {
                     // Remeber to clean the stream.
                     uploadStream.Dispose();
                 });
                var result = task.Result;
            }
            catch (Exception EX)
            {
            }
        }
