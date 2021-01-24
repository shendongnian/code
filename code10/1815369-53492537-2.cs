    public static async Task GoAsync(
        SearchContract search,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var taskList = new List<Task<List<SearchModel>>>
        {
            SearchRoutine1Async(search, cancellationToken),
            SearchRoutine2Async( search, cancellationToken)
        };
        Task<List<SearchModel>> completedTask = await Task.WhenAny(taskList);
        // use competedTask.Result here (safe as you know task is completed)
    }
