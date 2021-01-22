    class OneShotHandlerQueue<TEventArgs> where TEventArgs : EventArgs {
        private ConcurrentQueue<EventHandler<TEventArgs>> queue;
        public OneShotHandlerQueue() {
            this.queue = new ConcurrentQueue<EventHandler<TEventArgs>>();
        }
        public void Handle(object sender, TEventArgs e) {
            EventHandler<TEventArgs> handler;
            if (this.queue.TryDequeue(out handler) && (handler != null))
                handler(sender, e);
        }
        public void Add(EventHandler<TEventArgs> handler) {
            this.queue.Enqueue(handler);
        }
    }
