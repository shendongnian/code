    public event EventHandler event1;
    public void ChangeHandlersOrdering()
    {
        if (event1 != null)
        {
            List<EventHandler> invocationList = event1.GetInvocationList()
                                                      .OfType<EventHandler>()
                                                      .ToList();
            foreach (var handler in invocationList)
            {
                event1 -= handler;
            }
            //Change ordering now, for example in reverese order as follows
            for (int i = invocationList.Count - 1; i >= 0; i--)
            {
                event1 += invocationList[i];
            }
        }
    }
