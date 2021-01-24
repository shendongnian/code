        public static event MessageReceivedEventHandler MessageReceivedEvent;
        protected override void OnMessage(MessageEventArgs e)
        {
            MessageReceivedEvent?.Invoke(this, e);
        }
