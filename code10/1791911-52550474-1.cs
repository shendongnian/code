    private async Task<string> GetDownloadsFolderPath()
    {
        StorageFile newFile = await DownloadsFolder.CreateFileAsync("mytestfile");
        if (newFile != null)
        {
            //You maybe need to operate the DownloadFolderPath string to subtract the folder name of your app.
            string DownloadFolderPath = newFile.Path;
            await newFile.DeleteAsync();
            return DownloadFolderPath;
        }
        else
        {
            return "There is an error to get path";
        }
    }
