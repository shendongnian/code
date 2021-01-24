    private TaskCompletionSource<bool> _paused = null;
    public async Task DoWork()
    {
        while (true)
        {
            if (_paused != null)
            {
                await _paused.Task;
                _paused = null;
            }
            //run work
            await Task.Delay(100);
        }
    }
    public void Pause()
    {
        _paused = _paused ?? new TaskCompletionSource<bool>();
    }
    public void UnPause()
    {
        _paused?.SetResult(true);
    }
