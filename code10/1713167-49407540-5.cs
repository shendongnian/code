    public class SubscriptionManager
    {
        public Publisher Publisher => new Publisher();
        private List<Subscriber> subscribers;
        public void Subscribe(Subscriber s)
        {
            if (!subscribers.Contains(s))
            {
                subscribers.Add(s);
                Publisher.NewsLetterPublished += s.ReceiveNewsLetter;
            }
        }
        public void Unsubscribe(Subscriber s)
        {
            if (subscribers.Contains(s))
            {
                subscribers.Remove(s);
                Publisher.NewsLetterPublished -= s.ReceiveNewsLetter;
            }
        }
    }
