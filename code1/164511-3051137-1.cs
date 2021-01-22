    class Listener
    {
        private HttpListener listener = null;
        public event EventHandler CommandReceived;
        public Listener()
        {
            this.listener = new HttpListener();
            this.listener.Prefixes.Add("http://localhost:12345/");
        }
        public void ContextReceived(IAsyncResult result)
        {
            if (!this.listener.IsListening)
            {
                return;
            }
            HttpListenerContext context = this.listener.EndGetContext(result);
            this.listener.BeginGetContext(this.ContextReceived, this.listener);
            if (context != null)
            {
                EventHandler handler = this.CommandReceived;
                handler(context, new EventArgs());
            }
        }
        public void Start()
        {
            this.listener.Start();
            this.listener.BeginGetContext(this.ContextReceived, this.listener);
        }
        public void Stop()
        {
            this.listener.Stop();
        }
    }
