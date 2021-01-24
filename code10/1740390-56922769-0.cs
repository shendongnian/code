    public class MyTest
        {
            private readonly ISubscriber subscriber; 
    
            public MyTest()
            {
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
                this.subscriber = redis.GetSubscriber();
            }
    
            public void SubscribeWithPattern(string pattern)
            {
                RedisChannel channelWithPattern = new RedisChannel(pattern, RedisChannel.PatternMode.Pattern);
                string originalChannelSubcription = pattern;
                this.subscriber.Subscribe(channelWithPattern, (channel, message) =>
                {
                    Console.WriteLine($"OriginalChannelSubcription '{originalChannelSubcription}");
                    Console.WriteLine($"Channel: '{channel}");
                    Console.WriteLine($"Message: '{message}'");
                });
            }
    
            public void Publish(string channel, string message)
            {
                this.subscriber.Publish(channel, message);
            }
        }
