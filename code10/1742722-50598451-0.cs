    public async Task<IEnumerable<StorageFile>> SearchForFileAsync(StorageFolder folder, string fileName)
    {
        var results = new List<StorageFile>();
        await SearchForFileCoreAsync(folder, fileName, results);
        return results;
    }
    
    private async Task SearchForFileCoreAsync(StorageFolder folder, string fileName, List<StorageFile> results)
    {
        var subfolders = await folder.GetFoldersAsync();
        var files = await folder.GetFilesAsync();
        var file = files.FirstOrDefault(f => f.Name == fileName);
        if (file != null)
        {
            results.Add(file);
        }
    
        foreach (var subfolder in subfolders)
        {
            await SearchForFileCoreAsync(subfolder, fileName, results);
        }
    }
