        // Define a type independent class to contain event data
        public class EventArgs<T> : EventArgs
        {
        public EventArgs(T value)
        {
            m_value = value;
        }
        private T m_value;
        public T Value
        {
            get { return m_value; }
        }
    }
    // Create a type independent event handler to maintain a list of events.
    public static class EventDispatcher<TEvent> where TEvent : new()
    {
        static Dictionary<TEvent, EventHandler> Events = new Dictionary<TEvent, EventHandler>();
        // Add a new event to the list of events.
        static public void CreateEvent(TEvent Event)
        {
            Events.Add(Event, new EventHandler((s, e) => 
            {
                // Insert possible default action here, done every time the event is fired.
            }));
        }
        // Add a subscriber to the given event, the Handler will be called when the event is triggered.
        static public void Subscribe(TEvent Event, EventHandler Handler)
        {
            Events[Event] += Handler;
        }
        // Trigger the event.  Call all handlers of this event.
        static public void Fire(TEvent Event, object sender, EventArgs Data)
        {
            if (Events[Event] != null)
                Events[Event](sender, Data);
        }
    }
