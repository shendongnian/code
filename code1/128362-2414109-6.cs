    namespace MyExample
    {
        public class EventsSubscriptions
        {
            private Dictionary<string, Subscription> subscriptions = new Dictionary<string, Subscription>();
    
            public Subscription this[string id]
            {
                get
                {
                    Subscription subscription = null;
    
                    subscriptions.TryGetValue(id, out subscription);
    
                    if (subscription == null)
                    {                    
                        subscription = new Subscription();
                        subscriptions.Add(id, subscription);
                    }
    
                    return subscription;
    
                }
            }
    
            public void RaiseAllEvents()
            {
                foreach (Subscription subscription in subscriptions.Values)
                {
                    Subscription iterator = subscription;
    
                    while (iterator != null)
                    {
                        iterator.RaiseEvent();
                        iterator = iterator.NextSubscription;
                    }
                }
            }
    
    
        }
    }
