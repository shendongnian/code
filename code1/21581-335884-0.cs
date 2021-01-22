    public delegate void IdleCallback();
    public interface IdleNotifier
    {
        // Called by threadpool when more than IdleTimeSpanBeforeCallback 
        // has passed since last call on ActionOccured.
        IdleCallback Callback { set; }
        TimeSpan IdleTimeSpanBeforeCallback { set; }
        void ActionOccured();
    }
