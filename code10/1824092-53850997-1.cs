    protected virtual void Dispose(bool disposing) {
        if (disposing) {
            lock(this) {
                if (site != null && site.Container != null) {
                    site.Container.Remove(this);
                }
                if (events != null) {
                    EventHandler handler = (EventHandler)events[EventDisposed];
                    if (handler != null) handler(this, EventArgs.Empty);
                }
            }
        }
    }
