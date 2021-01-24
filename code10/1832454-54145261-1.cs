    static async Task<MethodResponse> MyDirectMethodHandler(MethodRequest methodRequest, object userContext)
    {
        Console.WriteLine($"My direct method has been called!");
        var payload = methodRequest.DataAsJson;
        Console.WriteLine($"Payload: {payload}");
            
        try
        {
            // perform your computation using the payload
        }
        catch (Exception e)
        {
             Console.WriteLine($"Computation failed! Error: {e.Message}");
             return new MethodResponse(Encoding.UTF8.GetBytes("{\"errormessage\": \"" + e.Message + "\"}"), 500);
        }
            
        Console.WriteLine($"Computation successfull.");
        return new MethodResponse(Encoding.UTF8.GetBytes("{\"status\": \"ok\"}"), 200);
    }
