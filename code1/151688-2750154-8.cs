    class Counter
    {
        EventHandler savedEvent;
        public Counter()
        {
            savedEvent = CountEvent;
        }
        public void CountSaved()
        {
            producer.EventRaised += savedEvent;
            producer.Raise();
            producer.EventRaised -= savedEvent;
        }
    }
