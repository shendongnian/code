    public async Task Main()
    {
    	var result = await Background("Test");
    	// Update Ui here, its on Ui thread
    }
    
    // Executed Asynchronously in the Background
    public async Task<string> Background(string text)
    {
    	return await Task.FromResult(text);
    }
