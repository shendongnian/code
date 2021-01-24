    public delegate Object EventType();
    public class PublisherClass
    {
        private event EventType Event;
        public event EventType EventAccessor
        {
            add { Event += value; }
            remove { Event -= value; }
        }
        
        public void RaiseAnEvent()
        {
            if (Event != null) { Event(); }
        }
    }
