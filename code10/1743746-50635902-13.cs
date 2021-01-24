    public delegate Object EventType();
    public class PublisherClass
    {
        public event EventType Event;
        public PublisherClass()
        {
            SubscriberClass d2 = new SubscriberClass(ref Event);
            if (Event != null)
            {
                Event();
            }
        }
    }
