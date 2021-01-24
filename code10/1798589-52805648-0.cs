    var logsFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(
                             "Logs", CreationCollisionOption.OpenIfExists);
    var items = (await logsFolder.GetItemsAsync()).ToArray();
    foreach (var item in items)
    {
        try
        {
            await item.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }
        catch
        {
            //ignore exception - could happen if some file is currently open
        }
    }
