    public sealed class EventPublisher : IEventPublisher
    {
        public async Task PublishAsync<T>(T eventMessage)
        {
            var subscriptions = DependencyResolver.ResolveAll<IConsumer<T>>();
            foreach (var subscription in subscriptions)
            {
                await subscription.HandleEventAsync(eventMessage);
            }
        }
    }
