    public void SubScribeChannel()
    {
        string channelName = _config.ActiveChannelName;
        using (var redisConsumer = new RedisClient(_config.SingleHost))
        using (var subscription = redisConsumer.CreateSubscription())
        {
            subscription.OnSubscribe = channel =>
            {
                Debug.WriteLine(String.Format("Subscribed to '{0}'", channel));
            };
            subscription.OnUnSubscribe = channel =>
            {
                Debug.WriteLine(String.Format("UnSubscribed from '{0}'", channel));
            };
            subscription.OnMessage = async (channel, msg) =>
            {
                Debug.WriteLine(String.Format("Received '{0}' from channel '{1}'", msg, channel));
                List<Document> documents = Transformer.Deserialize<List<Document>>(msg);
                await MergeToMongoDb(documents, channelName);
            };
            try
            {
                Debug.WriteLine(String.Format("SubscribeToChannels: '{0}'", channelName));
                //subscription.SubscribeToChannels(channelName);
                subscription.SubscribeToChannelsMatching(_config.ActiveChannelName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        Debug.WriteLine("EOF");
    }
