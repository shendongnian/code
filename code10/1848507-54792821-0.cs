    public Task Save(LogModel logObject)
    {
        List<Task> saveTasks = new List<Task>();
        LogInfo logInfo = logObject.logInfo;
        LogDetails logDetails = logObject.logDetails;
        saveTasks.Add(documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, primaryLogInfoCollectionID), logInfo));
        saveTasks.Add(documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, archieveLogInfoCollectionID), logInfo));    
        saveTasks.Add(documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, primaryLogDetailsCollectionID), logDetails));
        saveTasks.Add(documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, archieveLogDetailsCollectionID), logDetails));
        return Task.WhenAll(saveTasks.ToArrays());
    }
