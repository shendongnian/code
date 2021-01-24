    public class SubscriberClass
    {
        public SubscriberClass(PublisherClass p)
        {
            p.EventAccessor += d_Event;
        }
        object d_Event()
        {
            return null;
        }
    }
