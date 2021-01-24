    AWSRoot obj = new AWSRoot(input.Payload);
    var request = new PublishRequest
    {
        TargetArn = endpoint.EndpointArn,
        MessageStructure = "json",
        Message = JsonConvert.SerializeObject(obj)
    };
    PublishResponse publishResponse = await _client.PublishAsync(request);
