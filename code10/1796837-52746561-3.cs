    PubsubMessage msg = new PubsubMessage
    {
        Data = ByteString.CopyFromUtf8(JsonConvert.SerializeObject(payload))
    };
    pub.PublishAsync(topic, new[]{ msg });
