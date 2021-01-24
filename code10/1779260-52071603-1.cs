    UserCredential credential;
                string credPath = System.Environment.GetFolderPath(
                   System.Environment.SpecialFolder.Personal);
    
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                       new[] { CalendarService.Scope.CalendarReadonly },
                        "user", CancellationToken.None, new FileDataStore(credPath));
                }
