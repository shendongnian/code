    public static class EventExtension
    {
        public static void RaiseEvent<T>(this EventHandler<T> handler, object obj, T args) where T : EventArgs
        {
            if (handler != null)
            {
                handler(obj, args);
            }
        }
    }
