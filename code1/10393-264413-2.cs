    // Usage
    EventHelper.Fire(MyEvent, this, EventArgs.Empty);
        
    
    public static void Fire(EventHandler del, object sender, EventArgs e)
    {
        UnsafeFire(del, sender, e);
    }
    private static void UnsafeFire(Delegate del, params object[] args)
    {
        if (del == null)
        {
            return;
        }
        Delegate[] delegates = del.GetInvocationList();
        foreach (Delegate sink in delegates)
        {
            try
            {
                sink.DynamicInvoke(args);
            }
            catch
            { }
        }
    }
