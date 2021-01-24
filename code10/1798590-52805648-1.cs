    private async void Export()
    {
        var logsFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(
            "Logs", 
            CreationCollisionOption.OpenIfExists);
 
        //first delete existing export if there is one
        var zipFile = await ApplicationData.Current.LocalFolder
                               .TryGetItemAsync("LogsExport.zip");
        zipFile?.DeleteAsync();
 
        //create zip export of logs
        ZipFile.CreateFromDirectory(logsFolder.Path, 
                                    Path.Combine(
                                         ApplicationData.Current.LocalFolder.Path,
                                         "LogsExport.zip"),
                                    CompressionLevel.Fastest, true);
        //do something with the exported file 
        var dataTransferManager = DataTransferManager.GetForCurrentView();
        dataTransferManager.DataRequested += DataTransferManager_DataRequested;
        DataTransferManager.ShowShareUI();
    }
    
    private async void DataTransferManager_DataRequested(DataTransferManager sender,
                                                         DataRequestedEventArgs args)
    {
        var dataRequest = args.Request;
        var deferral = dataRequest.GetDeferral();
        var file = await StorageFile.GetFileFromPathAsync(
            Path.Combine(ApplicationData.Current.LocalFolder.Path,
            "LogsExport.zip"));            
        dataRequest.Data.SetStorageItems(new IStorageItem[]{ file });
        //unsubscribe event
        var dataTransferManager = DataTransferManager.GetForCurrentView();
        dataTransferManager.DataRequested -= DataTransferManager_DataRequested;
        deferral.Complete();
    }
