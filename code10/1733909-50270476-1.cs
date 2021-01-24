    var scan = await dynamoDbContext.ScanAsync<SystemMessage>(conditions).GetRemainingAsync(result =>
    {
        if (result.Exception == null)
        {
            // result contains the data
        }
        else
        {
            Debug.LogError("Failed to get async table scan results: " + result.Exception.Message);
        }
    }, null);
