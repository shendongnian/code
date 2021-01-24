		int port = 8181;
		TcpListener listener = null;
		public void Awake()
		{
		    DontDestroyOnLoad(gameObject);
			StartCoroutine(Listen());
		}
		private IEnumerator Listen()
		{
			listener = new TcpListener(System.Net.IPAddress.Any, port);	
			// start listening
			listener.Start();
		 	listener.BeginGetContext(ListenerCallback, listener);
		}
		public void ListenerCallback(IAsyncResult result)
		{
		    HttpListener listener = (HttpListener)result.AsyncState;
		    // Call EndGetContext to complete the asynchronous operation.
		    HttpListenerContext context = listener.EndGetContext(result);
		    HttpListenerRequest request = context.Request;
		    //do your response-handling logic here
		    listener.BeginGetContext(ListenerCallback, listener);
		}
