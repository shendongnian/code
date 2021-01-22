	public class TcpServer
	{
		#region Public.		
		// Create new instance of TcpServer.
		public TcpServer(string ip, int port)
		{
 			_listener = new TcpListener(IPAddress.Parse(ip), port);
		}
		// Starts receiving incoming requests.		
		public void Start()
		{
 			_listener.Start();
			_ct = _cts.Token;
			_listener.BeginAcceptTcpClient(ProcessRequest, _listener);
		}
		// Stops receiving incoming requests.
		public void Stop()
		{ 
			// If listening has been cancelled, simply go out from method.
			if(_ct.IsCancellationRequested)
			{
				return;
			}
			// Cancels listening.
			_cts.Cancel();
			// Waits a little, to guarantee 
            // that all operation receive information about cancellation.
			Thread.Sleep(100);
			_listener.Stop();
		}
		#endregion
		#region Private.
		// Process single request.
		private void ProcessRequest(IAsyncResult ar)
		{ 
			//Stop if operation was cancelled.
			if(_ct.IsCancellationRequested)
			{
 				return;
			}
						
			var listener = ar.AsyncState as TcpListener;
			if(listener == null)
			{
 				return;
			}
			// Check cancellation again. Stop if operation was cancelled.
			if(_ct.IsCancellationRequested)
			{
 				return;
			}
			// Starts waiting for the next request.
			listener.BeginAcceptTcpClient(ProcessRequest, listener);
			
			// Gets client and starts processing received request.
			using(TcpClient client = listener.EndAcceptTcpClient(ar))
			{
 				var rp = new RequestProcessor();
				rp.Proccess(client);
			}
		}
		#endregion
		#region Fields.
		private CancellationToken _ct;
		private CancellationTokenSource _cts = new CancellationTokenSource();
		private TcpListener _listener;
		#endregion
	}
