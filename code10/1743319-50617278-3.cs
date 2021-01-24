    private async static Task MethodWithParameter(string message)
    {
        try
        {
            await MQTTPublisher.RunAsync(message);
        }
        catch (Exception Ex)    
        {
        }            
    }
