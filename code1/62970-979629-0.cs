    public class Class1
    {
        // TODO: Think of a better name :)
        public event EventHandler ExecuteCalled = delegate {};
        public void Execute()
        {
            ExecuteCalled(this, EventArgs.Empty);
            // Do your normal stuff
        }
    }
