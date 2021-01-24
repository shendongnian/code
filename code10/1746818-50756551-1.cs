    public void Info(string action, string message)
    {
        Post(action, message, LogLevel.Info); // Unawaited Task, thread #1
    }
    private async Task Post(string action, string message, LogLevel logLevel)
    {
        var jsonData = JsonConvert.SerializeObject(log); // #1
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json"); // #1
        var response = await httpClient.PostAsync(...), content);
        // Work here will be scheduled on any available Thread, after PostAsync completes #2
    }
