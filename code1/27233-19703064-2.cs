    public static void RaiseEvent()
    {
        for (int i = 0; i < MAX_EVENT_LISTENERS; i++)
        {
            EventWaitHandle evt;
            if (EventWaitHandle.TryOpenExisting(EVENT_NAME + i, out evt))
            {
                evt.Set();
                evt.Dispose();
            }
        }
    }
