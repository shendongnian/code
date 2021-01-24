    public async Task<string> ControllerFunction()
    {           
        return await ControllerFunctionTask();
    }
    
    public Task<string> ControllerFunctionTask()
    {            
        sendMessage("a message");
    
        var task = new TaskCompletionSource<string>();
        localServer.OnMessage = (message) =>
        {
            task.SetResult(message);
        };
    
        return task.Task;
    }
