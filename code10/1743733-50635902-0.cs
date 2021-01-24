    public delegate Object EventType();
    public class PublisherClass
    {
        public event EventType Event;
        
        public void RaiseAnEvent()
        {
            if (Event != null) { Event(); }
        }
    }
