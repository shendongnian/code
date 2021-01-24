    private void Webview_ScriptNotify(object sender, NotifyEventArgs e)
    {
        var result = e.Value;
        resultimage = result.Substring(result.IndexOf(",")+1);
    }
    private async void btngetblob_Click(object sender, RoutedEventArgs e)
    { 
        byte[] imageBytes = Convert.FromBase64String(resultimage);
        StorageFolder storageFolder = await KnownFolders.GetFolderForUserAsync(null /* current user */, KnownFolderId.PicturesLibrary);
        StorageFile file = await storageFolder.CreateFileAsync("new.jpg", CreationCollisionOption.ReplaceExisting);
        using (IRandomAccessStream randomstream = await file.OpenAsync(FileAccessMode.ReadWrite))
        {
            DataWriter writer = new DataWriter(randomstream);
            writer.WriteBytes(imageBytes);
            await writer.StoreAsync();
            await writer.FlushAsync(); 
        }
    }
