    var folder= graphserviceClient.Me.Drive.Root.Children.Request()
                .AddAsync(new DriveItem
                {
                    Name = "tomfolder",
                    Folder = new Folder()
                }).Result;
    
    var subfolder = graphserviceClient.Me.Drive.Items[folder.Id].Children.Request()
                    .AddAsync(new DriveItem 
                    {
                      Name = "subfolder",
                      Folder = new Folder()}
                    ).Result;
