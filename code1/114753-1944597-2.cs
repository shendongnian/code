	internal class SendKeysClass
	{
		private bool _canSend;
		public SendKeysClass(Form form)
		{
			form.Activated += (sender, args) => _canSend = true;
			form.Deactivate += (sender, args) => _canSend = false;
		}
		public void Send(string keys)
		{
			if (!_canSend)
				return;
			SendKeys.Send(keys);
		}
	}
