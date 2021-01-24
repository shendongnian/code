    StorageFolder photos = KnownFolders.CameraRoll;
    // Create a query containing all the files your app will be tracking
    QueryOptions option = new QueryOptions(CommonFileQuery.DefaultQuery,
      supportedExtentions);
    option.FolderDepth = FolderDepth.Shallow;
    // This is important because you are going to use indexer for notifications
    option.IndexerOption = IndexerOption.UseIndexerWhenAvailable;
    StorageFileQueryResult resultSet =
      photos.CreateFileQueryWithOptions(option);
    // Indicate to the system the app is ready to change track
    await resultSet.GetFilesAsync(0, 1);
    // Attach an event handler for when something changes on the system
    resultSet.ContentsChanged += resultSet_ContentsChanged;
