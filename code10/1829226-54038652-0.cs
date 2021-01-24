    try
    {
        AssetSyncResult[] syncResults = await Task.WhenAll(tasks);
    }
    catch (System.Exception)
    {
    
    }
    
    var passedResults = tasks.Where(r => r.Status == TaskStatus.RanToCompletion).Select(r => r.Result).ToList();
