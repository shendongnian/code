    public static void Main(string[] args) {    
        var jsonSerializer = new JsonSerializer();
        var lambdaConfig = new AmazonLambdaConfig() { RegionEndpoint = RegionEndpoint.USEast2 };
        var lambdaClient = new AmazonLambdaClient(lambdaConfig);
        
        var memoryStream = new MemoryStream();
        
        jsonSerializer.Serialize(myData, memoryStream);
        var lambdaRequest = new InvokeRequest
        {
            FunctionName = "MyFunction",
            InvocationType = "Event",
            PayloadStream = memoryStream
        };
        
        lambdaClient.InvokeAsync(lambdaRequest);
        
        Console.ReadLine();
    }
