    public class SubscriptionServer : ISubscriptionServer
    {
        private static ImmutableDictionary<Guid, Subscriber> subscribers = ImmutableDictionary<Guid, Subscriber>.Empty;
        public void SubscribeEvent(string id)
        {
            subscribers = subscribers.Add(Guid.NewGuid(), new Subscriber());
        }
        public void NotifyEvent()
        {
            foreach(var sub in subscribers.Values)
            {
                //.....This is always safe
            }
        }
        //.........
    }
