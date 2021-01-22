    class MyClassThatFiresWithoutTheTrick
    {
        public event EventHandler MyEvent; // implicit = null
        // Need a method to keep this DRY as each fire requires a null check
        void FireMyEvent()
        {
            // Need to do this check as it might not have been overridden
            if( MyEvent == null)
                return;
            MyEvent( this, EventArgs.Empty );
        }
    }
    class MyClassThatFiresWithTheTrick
    {
        public event EventHandler MyEvent = delegate{};
        void FireMyEvent()
        {
            MyEvent( this, EventArgs.Empty );
        }
    }
