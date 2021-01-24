    var bytes = your bytes;
    var serializer = DataContractBinarySerializer<byte[]>.Instance;
    using (MemoryStream stream = new MemoryStream())
    {
        serializer.WriteObject(stream, bytes);
        var msg = new Message(stream.ToArray());
        var client = new Microsoft.Azure.ServiceBus.QueueClient(ConnectionString, Queue);
        await client.SendAsync(msg);
        await client.CloseAsync();
    }
