     public static DriveService InitService(ref string errorString, string Log_Filename)
        {
            try
            {
                string[] Scopes = { DriveService.Scope.DriveReadonly };
                UserCredential credential;
                if (!System.IO.File.Exists(credential_json))
                {
                    System.Windows.Forms.MessageBox.Show("Unable to Initialise Google Drives Service credentials not found.");
                    Helpers.Helpers_TextFile.TextFile_WriteTo(Log_Filename, "Google Drive Init - Unable to Initialise Google Drives Service credentials not found.");
                }
                using (var stream = new FileStream(credential_json, FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    if (credential.UserId == "user")
                    {
                        Helpers.Helpers_TextFile.TextFile_WriteTo(Log_Filename, "Google Drive Init - Credentials file saved to: " + credPath);
                    }
                    else {
                        Helpers.Helpers_TextFile.TextFile_WriteTo(Log_Filename, "Google Drive Init - Unable to verify credentials.");
                        return null;
                    }
                }
                // Create Drive API service
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                // Validate Service
                if (service.Name == "drive" && service.ApplicationName == ApplicationName)
                {
                    Helpers.Helpers_TextFile.TextFile_WriteTo(Log_Filename, "Google Drive Init - Google Service Created.");
                }
                else
                {
                    Helpers.Helpers_TextFile.TextFile_WriteTo(Log_Filename, "Google Drive Init - Unable to create service.");
                    return null;
                }
                return service;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show("An Error Occured While Initialising Google Drives Service");
                System.Windows.Forms.Clipboard.SetText(Ex.ToString());
                Helpers.Helpers_TextFile.TextFile_WriteTo(Log_Filename, "Google Drive Init - Error Occurred: " + Ex.ToString());
                errorString = Ex.Message;
            }
            return null;
        }
