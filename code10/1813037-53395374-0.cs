    // An async event handler
    public async void Button_Click(...)
    {
        ...
        var exists = await DirectoryExists(myPath);
        ...
    }
    public async Task<bool> DirectoryExists(string path)
    {
        return await Task.Run<bool>(() => Directory.Exists(path));
    }
