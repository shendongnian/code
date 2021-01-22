    class EventProducer
    {
        public void Raise()
        {
            var handler = EventRaised;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        public event EventHandler EventRaised;
    }
    class Counter
    {
        long count = 0;
        EventProducer producer = new EventProducer();
        public void Count()
        {
            producer.EventRaised += CountEvent;
            producer.Raise();
            producer.EventRaised -= CountEvent;
        }
        public void CountWithNew()
        {
            producer.EventRaised += new EventHandler(CountEvent);
            producer.Raise();
            producer.EventRaised -= new EventHandler(CountEvent);
        }
        private void CountEvent(object sender, EventArgs e)
        {
            count++;
        }
    }
