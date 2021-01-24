    public async Task<IEnumerable<StorageFile>> ProcessFiles(StorageFolder folder, Action<StorageFile> process)
    {
        var items = await folder.GetItemsAsync();          
        foreach (var item in items)
        {
            if (item.GetType() == typeof(StorageFile))
                process(item);
            else
               await ProcessFiles(item as StorageFolder);
        }
    }
    ProcessFiles(folder, file => {
        ProcessFile(file);
        DisposeFile(file);
    });
