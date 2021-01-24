    public class A
    {
        public event EventHandler MyEvent;
        public void SubscribeToEvent(EventHandler function)
        {
            this.MyEvent += function;
        }
        public void UnsubscribeToEvent(EventHandler function)
        {
            this.MyEvent -= function;
        }
    }
