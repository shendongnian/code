    public async Task<IEnumerable<StorageFile>> SearchForFileAsync(StorageFolder folder, string fileName)
    {            
        QueryOptions options = new QueryOptions();
        options.ApplicationSearchFilter = "myfile.txt";
        options.FolderDepth = FolderDepth.Deep;
        var query = folder.CreateFileQueryWithOptions(options);                        
        return await query.GetFilesAsync(); 
    }
