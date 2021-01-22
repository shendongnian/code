    public static void RaiseEvent(ref EventHandler handler, object sync,
        object sender, EventArgs e)
    {
        EventHandler handlerCopy;
        lock (sync)
        {
            handlerCopy = handler;
        }
        if (handlerCopy != null)
        {
            handlerCopy(sender, e);
        }
    }
