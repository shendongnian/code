	class Test : IDriver
	{
		private Connection _connection;
		private Action<OperationResponse> _callback;
		public void Initialize()
		{
			_connection = new Connection(new ResponseCallback(ResponseReceived));
		}
		public void Begin(Action<OperationResponse> callback)
		{
			_connection.SendRequest();
			_callback = callback;
		}
		private void ResponseReceived(object source, MessageReceivedArgs e)
		{
			_callback(responseInstanceHere);
		}
