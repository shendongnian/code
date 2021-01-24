    public static async Task GoAsync(
        SearchContract search,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var taskList = new List<Task>
        {
            SearchRoutine1Async(search, cancellationToken),
            SearchRoutine2Async( search, cancellationToken)
        };
        Task completedTask = await Task.WhenAny(taskList);
    }
