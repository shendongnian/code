    if (ZipFolder != null)
    {
        // Application now has read/write access to all contents in the picked folder (including other sub-folder contents)
        StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", ZipFolder);
        await Task.Run(() =>
        {
            try
            {
                ZipFile.CreateFromDirectory(ApplicationData.Current.LocalFolder.Path, $"{ZipFolder.Path}\\{Guid.NewGuid()}.zip");
                Debug.WriteLine("folder zipped");
            }
            catch (Exception w)
            {
                Debug.WriteLine(w);
            }
        });
    
    }
