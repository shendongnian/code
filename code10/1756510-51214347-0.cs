    public async Task TestFullTextSearch()
    {
        StorageFolder folder = await ApplicationData.Current.LocalCacheFolder.CreateFolderAsync("Indexed", CreationCollisionOption.OpenIfExists);
        CreateFile(folder.Path + Path.DirectorySeparatorChar + "myDocument.txt", "Some text 123");
        await Task.Delay(5000); // to ensure that the file is already index before querying
        int numberOfResults = await SearchForResults(folder, "*");
        // numberOfResults is 1 in Windows 10, 1709 and 1 in 1803
    }
    public void CreateFile(string path, string text)
    {
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(text);
        }
    }
    private async Task<int> SearchForResults(StorageFolder folder, string searchString)
    {
        QueryOptions queryOptions = new QueryOptions(CommonFileQuery.OrderBySearchRank, new List<string>() { "*" });
        queryOptions.UserSearchFilter = searchString;
        StorageFileQueryResult queryResult = folder.CreateFileQueryWithOptions(queryOptions);
        IReadOnlyList<StorageFile> files = await queryResult.GetFilesAsync();
        return files.Count;
    }
