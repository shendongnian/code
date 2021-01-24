    public class MySyncContext : SynchronizationContext
    {
        public string State { get; set; }
        public override void Post(SendOrPostCallback callback, object state)
        {
            base.Post(s => { 
                SynchronizationContext.SetSynchronizationContext(this);
                callback(s);
            }, state);
        }
        public override string ToString() => State;
    }
