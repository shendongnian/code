    private static Dictionary<string, string[]> GetFacebookData(string idsString)
    {
        var allDataDictionary = new Dictionary<string, string[]>();
        var idsArray = idsString.Split(',');
        var getDataTasks = new List<Task<string[]>>();
        foreach (var id in idsArray)
        {
            getDataTasks.Add(FacebookClient.GetDataAsync<string[]>(id));         
        }
        var tasksArray = getDataTasks.ToArray();
        Task.WaitAll(tasksArray);
        var resultsArray = tasksArray.Select(task => task.Result).ToArray();
        for (var i = 0; i < idsArray.Length; i++)
        {
            allDataDictionary.Add(idsArray[i], resultsArray[i]);
        }
        return allDataDictionary;
    }
