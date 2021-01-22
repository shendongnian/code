    ...
    EventWaitHandle evt = GetEvent();
    do
    {
        bool b = evt.WaitOne();
        // event was set!
    }
    while (true);
    ....
    // create our own event that no other listener has
    public static EventWaitHandle GetEvent()
    {
        for (int i = 0; i < MAX_EVENT_LISTENERS; i++)
        {
            bool createdNew;
            EventWaitHandle evt = new EventWaitHandle(false, EventResetMode.AutoReset, EVENT_NAME + i, out createdNew);
            if (createdNew)
                return evt;
    
            evt.Dispose();
        }
        throw new Exception("Increase MAX_EVENT_LISTENERS");
    }
