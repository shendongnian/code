    class MyClassThatFiresWithoutTheTrick
    {
        public event EventHandler MyEvent; // implicit = null
        // Need a method to keep this DRY as each fire requires a null check - see Framework Design Guidelines by Abrams and Cwalina
        protected virtual void OnMyEvent()
        {
            // need to take a copy to avoid race conditions with _removes
            var handler = MyEvent;
            // Need to do this check as it might not have been overridden
            if( handler == null)
                return;
            handler( this, EventArgs.Empty );
        }
    }
    class MyClassThatFiresWithTheTrick
    {
        public event EventHandler MyEvent = delegate{};
        protected virtual void OnMyEvent()
        {
            MyEvent( this, EventArgs.Empty );
        }
    }
