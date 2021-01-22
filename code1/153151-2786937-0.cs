    public static class EventHandlerExtensions
    {
        public static void FireEvent<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            var temp = handler;
            if (temp != null)
            {
                temp(sender, args);
            }
        }
        public static void FireEvent(this EventHandler handler, object sender)
        {
            var temp = handler;
            if (temp != null)
            {
                temp(sender, EventArgs.Empty);
            }
        }
    }
