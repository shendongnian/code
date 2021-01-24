    public ServieResponse SaveFileOnGoogleDrive(string url)
       {
           //string url = string.Empty; ; ;
           //string[] scopes = new string[] { DriveService.Scope.Drive,
           //                 DriveService.Scope.DriveFile};
           string[] scopes = new string[] { DriveService.Scope.Drive,
                          DriveService.Scope.DriveAppdata,
                          //DriveService.Scope.DriveAppsReadonly,
                          DriveService.Scope.DriveFile,
                          DriveService.Scope.DriveMetadataReadonly,
                          DriveService.Scope.DriveReadonly,
                          DriveService.Scope.DriveScripts };
           var clientId = "65675933715-poet7f7dhjhrmccmalhb41pltho7tusr.apps.googleusercontent.com";      // From https://console.developers.google.com
           var clientSecret = "D8USyz3Pf82wOMi6l2pJehjx";
           // From https://console.developers.google.com
           // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
           var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
           {
               ClientId = clientId,
               ClientSecret = clientSecret
           },
                                                                   scopes,
                                                                   Environment.UserName,
                                                                   CancellationToken.None,
                                                                   new FileDataStore("MyAppsToken")).Result;
           //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.
           DriveService service = new DriveService(new BaseClientService.Initializer()
           {
               HttpClientInitializer = credential,
               ApplicationName = "CTM",
           });
           string filePath = WebConfigurationManager.AppSettings["filPath"];
           filePath = HttpContext.Current.Server.MapPath(filePath) + url;
           uploadFile(service, filePath);
           ServieResponse ob = new ServieResponse();
           ob.ResponseMsg = "Success";
           return ob;
       }
    public static void uploadFile(DriveService _service, string _uploadFile)
      {
          if (System.IO.File.Exists(_uploadFile))
          {
              var body = new Google.Apis.Drive.v3.Data.File();
              //File body = new File();
              body.Name = System.IO.Path.GetFileName(_uploadFile);
              //body.Description = _descrp;
              body.MimeType = GetMimeType(_uploadFile);
              // body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
              FilesResource.CreateMediaUpload request;
              try
              {
                  using (var stream = new System.IO.FileStream(_uploadFile, System.IO.FileMode.Open))
                  {
                      request = _service.Files.Create(body, stream, body.MimeType);
                      request.Fields = "id";
                      request.Upload();
                  }
                  var file = request.ResponseBody;
                  var fili = file.Id;
              }
              catch (Exception e)
              {
              }
          }
          else
          {
          }
      }
    private static string GetMimeType(string fileName)
      {
          string mimeType = "application/unknown";
          string ext = System.IO.Path.GetExtension(fileName).ToLower();
          Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
          if (regKey != null && regKey.GetValue("Content Type") != null)
              mimeType = regKey.GetValue("Content Type").ToString();
          return mimeType;
      }
