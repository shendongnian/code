    public interface ISomeClassWithEvent
    {
        event EventHandler<EventArgs> Changed;
    }
    public class SomeClassWithEvent : ISomeClassWithEvent
    {
        public event EventHandler<EventArgs> Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
    }
