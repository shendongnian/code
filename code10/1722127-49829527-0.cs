    public class ChatApi
    {
        private readonly HubConnection _connection;
        private ConnectionState _connectionState = ConnectionState.Disconnected;
        public ChatApi()
        {
            var connection = new HubConnectionBuilder();
            _connection = connection.WithUrl("https://localhost:44302/chathub").Build();
            // Subscribe to event
            _connection.Closed += (ex) =>
            {
                if (ex == null)
                {
                    Trace.WriteLine("Connection terminated");
                    _connectionState = ConnectionState.Disconnected;
                }
                else
                {
                    Trace.WriteLine($"Connection terminated with error: {ex.GetType()}: {ex.Message}");
                    _connectionState = ConnectionState.Faulted;
                }
            };
        }
        public async Task StartIfNeededAsync()
        {
            if (_connectionState == ConnectionState.Connected)
            {
                return;
            }
            try
            {
                await _connection.StartAsync();
                _connectionState = ConnectionState.Connected;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Connection.Start Failed: {ex.GetType()}: {ex.Message}");
                _connectionState = ConnectionState.Faulted;
                throw;
            }
        }
        private enum ConnectionState
        {
            Connected,
            Disconnected,
            Faulted
        }
    }
