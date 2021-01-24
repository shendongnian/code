    StorageFile destinationFile;
    StorageFolder downloadsFolder;
    try
    {
        try
        {
            downloadsFolder = await DownloadsFolder.CreateFolderAsync("AppFiles");
            string folderToken = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(downloadsFolder);
            ApplicationData.Current.LocalSettings.Values["folderToken"] = folderToken;
            destinationFile = await downloadsFolder.CreateFileAsync("destination.txt", CreationCollisionOption.GenerateUniqueName);
        }
        catch (Exception ex)
        {
            if (ApplicationData.Current.LocalSettings.Values["folderToken"] != null)
            {
                string token = ApplicationData.Current.LocalSettings.Values["folderToken"].ToString();
                downloadsFolder = await Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.GetFolderAsync(token);
                destinationFile = await downloadsFolder.CreateFileAsync("destination.txt", CreationCollisionOption.GenerateUniqueName);
            }
        }
                
    }
    catch (FileNotFoundException ex)
    {
        rootPage.NotifyUser("Error while creating file: " + ex.Message, NotifyType.ErrorMessage);
        return;
    }
