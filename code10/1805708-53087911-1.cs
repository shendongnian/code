    var existingIds = new HashSet<string>(
            existingDocuments.Select(doc => doc.UniqueID.ToString()));
    for(int i = 0; i < cleanupDocList.Count; i++)
    {
        if (existingIds.Contains(cleanupDocList[i].id))
        { 
            toDelete.Add(cleanupDocList[i].filename);
        }
    }
    foreach(string fileToDelete in toDelete)
    {
        await _spManager.fileStorage.DeleteFileAsync(fileToDelete);
    }    
