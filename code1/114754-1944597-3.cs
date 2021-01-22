    internal class SendKeysClass
    {
        private bool _canSend;
        public SendKeysClass(Form form)
        {
            form.Activated += OnActivated;
            form.Deactivate += OnDeactivated;
        }
        private void OnDeactivated(object sender, EventArgs e)
        {
            _canSend = false;
        }
        private void OnActivated(object sender, EventArgs e)
        {
            _canSend = true;
        }
        public void Send(string keys)
        {
            if (!_canSend)
                return;
            SendKeys.Send(keys);
        }
    }
