    // Custom event args class
    public sealed class MyEventArgs
    {
        public string Result;
        public Deferral Deferral;
    }
    // Declare the event handler on the WinRT component
    public event TypedEventHandler<object, MyEventArgs> OnSuspendingEvent;
