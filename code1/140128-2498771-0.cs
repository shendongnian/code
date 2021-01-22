    class Visitor
    {
        private bool isSubscriber = false;
        public bool IsSubscriber
        {
             get { return isSubscriber; }
        }
        public void Subscribe()
        {
            // do some subscribing stuff
            isSubscriber = true;
        }
        public void Unsubscribe()
        {
            // do some unsubscribing stuff
            isSubscriber = false;
        }
    }
