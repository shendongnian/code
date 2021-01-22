    public static void Raise(this EventHandler eh, object sender, EventArgs e)
    {
        if (eh == null)
            return;
    
        foreach(var handler in eh.GetInvocationList().Cast<EventHandler>())
        {
            try
            {
                handler(sender, e);
            }
            catch { }
        }
    }
