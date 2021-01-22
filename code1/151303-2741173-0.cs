    ManualResetEvent[] CommandEventArr = new ManualResetEvent[] { NewOrderEvent, ExitEvent };
    while ((WaitHandle.WaitAny(CommandEventArr) != 1))
    {
        lock (PendingOrders)
        {
            if (PendingOrders.Count > 0)
            {
                fbo = PendingOrders.Dequeue();
            }
            else
            {
                fbo = null;
                NewOrderEvent.Reset();
            }
        }
    }
