	public class MyCustomCode{
		public PresenceHub(IPbxConnection connection)
		{
			hubConnection = new HubConnectionBuilder().WithUrl("localhost\mysignalrhub").Build();
            hubConnection.StartAsync().Wait();
			
			_connection = connection;
			_connection.OnUserUpdated((e) =>
			{                
				hubConnection.InvokeAsync("Send", e).Wait();
			});
			_connection.Connect();
		}
	}
