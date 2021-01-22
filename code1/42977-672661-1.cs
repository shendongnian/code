        public static void SafeInvoke(this EventHandler handler, object sender)
        {
            if (handler != null) handler(sender, EventArgs.Empty);
        }
        public static void SafeInvoke<T>(this EventHandler<T> handler,
            object sender, T args) where T : EventArgs
        {
            if (handler != null) handler(sender, args);
        }
