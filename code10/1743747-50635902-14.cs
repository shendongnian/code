    public class SubscriberClass
    {
        public SubscriberClass(ref EventType eve)
        {
            eve += d_Event;
        }
        object d_Event()
        {
            return null;
        }
    }
