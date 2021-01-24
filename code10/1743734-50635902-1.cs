    public class SubscriberClass
    {
        public SubscriberClass(PublisherClass p)
        {
            p.Event += d_Event;
        }
        object d_Event()
        {
            return null;
        }
    }
