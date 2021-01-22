        // Backing field
        // The underscores just make it simpler to see what's going on here.
        // In the rest of your source code for this class, if you refer to
        // ElementAddedEvent, you're really referring to this field.
        private EventHandler<EventArgs> __ElementAddedEvent;
        
        // Actual event
        public EventHandler<EventArgs> ElementAddedEvent
        {
            add
            {
                lock(this)
                {
                    // Equivalent to __ElementAddedEvent += value;
                    __ElementAddedEvent = Delegate.Combine(__ElementAddedEvent, value);
                }
            }
            remove
            {
                lock(this)
                {
                    // Equivalent to __ElementAddedEvent -= value;
                    __ElementAddedEvent = Delegate.Remove(__ElementAddedEvent, value);
                }
            }
        }
  - The initial value of the generated field in your case is null - and it will always become null again if all subscribers are removed, as that is the behaviour of Delegate.Remove.
