    public class EventService : IEventService
    {
        public void RaiseChanged(object sender, EventArgs e)
        {
            EventHandler handler = Changed;
            if (handler != null)
                handler(sender, e);
        }
        public event EventHandler Changed;
    }
