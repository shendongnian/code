    private async Task ZipFolderContentsHelper(StorageFolder sourceFolder, ZipArchive archive, string sourceFolderPath)
    {
        IReadOnlyList<StorageFile> files = await sourceFolder.GetFilesAsync();
    
        foreach (StorageFile file in files)
        {
            var path = file.Path.Remove(0, sourceFolderPath.Length);
            ZipArchiveEntry readmeEntry = archive.CreateEntry(file.Path.Remove(0, sourceFolderPath.Length));
            ulong fileSize = (await file.GetBasicPropertiesAsync()).Size;
            byte[] buffer = fileSize > 0 ? (await FileIO.ReadBufferAsync(file)).ToArray()
            : new byte[0];
    
          
            using (Stream entryStream = readmeEntry.Open())
            {
                await entryStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    
        IReadOnlyList<StorageFolder> subFolders = await sourceFolder.GetFoldersAsync();
    
        if (subFolders.Count() == 0)
        {
            return;
        }
    
        foreach (StorageFolder subfolder in subFolders)
        {
            await ZipFolderContentsHelper(subfolder, archive, sourceFolderPath);
        }
    }
