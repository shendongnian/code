    try
    {
        eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
        log.Info($"Azure Event sent");
    }
    catch (Exception e)
    {
        Console.WriteLine($"{DateTime.Now} > EventSender-exception {e.Message}");
    }
