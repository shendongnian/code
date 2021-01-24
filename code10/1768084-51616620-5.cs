    public class ConsumerHost : HostedService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var consumer = new Consumer<Null, string>(_config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(new string[] {"business-write-topic"});
                consumer.OnMessage += (_, msg) =>
                {
                    Console.WriteLine(
                        $"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");
                    consumer.CommitAsync(msg);
                };
                while (!cancellationToken.IsCancellationRequested) // will make sure to stop if the application is being shut down!
                {
                    consumer.Poll(100);
                    await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
                }
            }
        }
    }
