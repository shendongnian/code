    public async Task CreateFolder(string foldername)
    {
      string[] splitted = foldername.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
      var f = graphServiceClient.Me.Drive.Root;
      string p = "";
      IDriveItemRequestBuilder b;
      DriveItem driveItem;
      foreach (string folder in splitted)
      {
        p = string.Format("{0}{1}{2}", p, string.IsNullOrEmpty(p) ? "" : "/", folder);
        b = graphServiceClient.Me.Drive.Root.ItemWithPath(p);
        try
        {
          driveItem = await b.Request().GetAsync();
        }
        catch
        {
          driveItem = null;
        }
        if (driveItem == null)
        {
          var f2 = await f.Children.Request().AddAsync(new DriveItem()
          {
            Name = folder,
            Folder = new Folder()
          });
          b = graphServiceClient.Me.Drive.Root.ItemWithPath(p);
        }
        f = b;
      }
    }
