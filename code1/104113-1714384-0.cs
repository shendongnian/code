    void AddRemoveEvent(object target, string name, Delegate handler, bool add)
        where TArgs : System.EventArgs
    {
        EventInfo info = target.GetType().GetEvent(name);
        // Error handling left as an exercise for the reader :)
        if (add)
        {
            info.AddEventHandler(target, handler);
        }
        else
        {
            info.RemoveEventHandler(target, handler);
        }
    }
