    public async Task FilterNullTasks()
    {
        Task<string> myTask1 = Task.Delay(1000).ContinueWith(tsk => string.Empty);
        Task<int> myTask2 = null;
        Task<bool> myTask3 = null;
        await Task.WhenAll(new Task[]
        {
            myTask1, myTask2, myTask3
        }.Where(tsk => tsk != null);
    }
