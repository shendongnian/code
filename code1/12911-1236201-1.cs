    public static class EventUtils
    {
        public static void RaiseEvent(this EventHandler<EventArgs> handler, object obj, EventArgs args)
        {
            if (handler != null)
            {
                handler(obj, args);
            }
        }
    }
