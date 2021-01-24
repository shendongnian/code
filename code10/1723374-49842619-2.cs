    public async Task<Result> SomeAction()
    {
        var client = new AmazonSQSClient();
        // List all queues that start with "aws".
        var request = new ListQueuesRequest
        {
            QueueNamePrefix = "aws"
        };
        var response = await client.ListQueuesAsync(request);
        // rest of the code
    }
