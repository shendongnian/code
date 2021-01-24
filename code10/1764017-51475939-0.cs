    public async void HandleAsync()
    {
    	Debug.Log($"Foreground: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    	await WorkerAsync();
    	Debug.Log($"Foreground: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    }
    
    private async Task WorkerAsync()
    {
    	await Task.Delay(500);
    	Debug.Log($"Worker: {Thread.CurrentThread.ManagedThreadId}");
    	await Task.Run((System.Action)BackgroundWork);
    	await Task.Delay(500);
    	SceneManager.LoadScene("Scene2");
    }
    
    private void BackgroundWork()
    {
    	Debug.Log($"Background: {Thread.CurrentThread.ManagedThreadId}");
    }
