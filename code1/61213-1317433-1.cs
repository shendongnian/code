    public static class EventExtension
    {
        public static void RaiseEvent<T>(this EventHandler<T> handler, object obj, T args) where T : EventArgs
        {
            EventHandler<T> theHandler = handler;
            if (theHandler != null)
            {
                theHandler(obj, args);
            }
        }
    }
