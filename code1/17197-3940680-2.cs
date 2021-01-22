    public static void Raise(this EventHandler handler, object sender, EventArgs e)
    {
        if (handler != null)
        {
            handler(sender, e);
        }
    }
    public static void Raise<T>(this EventHandler<T> handler, object sender, T e) where T : EventArgs
    {
        if (handler != null)
        {
            handler(sender, e);
        }
    }
