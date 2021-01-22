    class RemoteCommand
    {
        public static SomeCommand SomeCommand
        {
            get
            {
                var result = new SomeCommand(/* ... */);
                // ...
                return result;
            }
        }
        public static SomeOtherCommand SomeOtherCommand { get { /* ... */ } }
    }
