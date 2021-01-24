    TaskCompletionSource<object> fileChanged = new TaskCompletionSource<object>();
    private void onFileChanged(object sender, EventArgs e)
    {
        fileChanged.TrySetResult(null);
    }
    private async Task endlessLoop()
    {
        while (true)
        {
            await handleFilesNotChanged();
        }
    }
    private async Task handleFilesNotChanged()
    {
        Task timeout = Task.Delay(TimeSpan.FromMinutes(5));
        Task waitForFile = fileChanged.Task;
        if (await Task.WhenAny(timeout, waitForFile) == timeout)
        {
            fireMyCode();
        }
        fileChanged = new TaskCompletionSource<object>();
    }
