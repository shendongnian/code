    // ConnectionManager.cs
    public static Dictionary<Guid, TaskCompletionSource<DataToSendToWebPage>> connectionTCSs;
    // WebPageRequestHandler.cs
    async Task HandleClientRequest() {
        // do some stuff
        var tcs = new TaskCompletionSource<DataToSendToWebPage>();
        ConnectionManager.connectionTCSs[deviceID] = tcs;
        var result = await tcs.Task; // This is where you wait for the other flow to complete
        // Write response to connection
    }
    // DeviceRequestHandler.cs
    void HandleRequest() {
        // do stuff
        ConnectionManager.connectionTCSs[clientID].SetResult(result);
    }
