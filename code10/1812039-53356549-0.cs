    public Task<BulkResponse<JObject>> GetRelatedObjectsAsync(
        IEnumerable<PrimaryObjectInfo> primaryObjectInfos)
    {
        var relatedObjectsTasks = primaryObjectInfos
            .Select(
                async primaryObjectInfo =>
                    (primaryObjectInfo.Index,
                     await objectManager.GetRelatedObjectsAsync(primaryObjectInfo)))
            .ToList();
        try
        {
            await Task.WhenAll(relatedObjectsTasks);
        }
        catch
        {
            // observe each task's, exception
        }
        var allSecondaries = new List<(int index, List<JObject> related)>();
        var exceptionsDict = new Dictionary<int, Exception>();
        foreach (var relatedObjectsTask in relatedObjectsTasks)
        {
            try
            {
                allSecondaries.Add(relatedObjectsTask.Result);
            }
            catch (Exception ex)
            {
                exceptionsDict.Add(relatedObjectsTask.index,  ex);
            }
        }
        return ConvertToBulkResponse(allSecondaries, exceptionsDict);
    }
