    public static void Raise(this EventHandler handler, object sender, EventArgs e)
    {
        if(handler != null)
        {
            handler(sender, e);
        }
    }
