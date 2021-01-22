    public static class MessageBus<T> where T : EventArgs
    {
        private static List<WeakReference> _handlers = new List<WeakReference>();
    
        public static event EventHandler<T> MessageReceived
        {
            add
            {
                _handlers.Add(new WeakReference(value));
            }
            remove
            {
                // also remove "dead" (garbage collected) handlers
                _handlers.RemoveAll(wh => !wh.IsAlive  || wh.Target.Equals(value));
            }
        }
        
        public static void SendMessage(object sender, T message)
        {
            foreach(var weakHandler in _handlers)
            {
                if (weakHandler.IsAlive)
                {
                    var handler = weakHandler.Target as EventHandler<T>;
                    handler(sender, message);
                }
            }            
        }
    }
