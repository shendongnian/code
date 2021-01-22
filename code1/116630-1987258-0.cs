        private static readonly object MyEventKey = new object();
        public event EventHandler MyEvent
        {
            add {Events.AddHandler(MyEventKey, value);}
            remove {Events.RemoveHandler(MyEventKey, value);}
        }
        protected virtual void OnMyEvent()
        {
            EventHandler handler = (EventHandler)Events[MyEventKey];
            if (handler != null) handler(this, EventArgs.Empty);
        }
