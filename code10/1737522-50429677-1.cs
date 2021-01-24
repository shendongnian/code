    public class NullEventBus : IEventBus
    {
        public void publish(string message) {
            // do nothing.
        }
    }
