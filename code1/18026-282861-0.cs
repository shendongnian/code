public class Test
{
    private EventHandler myEvent;
    private object eventLock = new object();
    private void OnMyEvent()
    {
        EventHandler handler;
        lock(this.eventLock)
        {
            handler = this.myEvent;
        }
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
    public event MyEvent
    {
        add
        {
            lock(this.eventLock)
            {
                this.myEvent += value;
            }
        }
        remove
        {
            lock(this.eventLock)
            {
                this.myEvent -= value;
            }
        }
    }
}
