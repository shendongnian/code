    public class HubClient : IHub
    {
        private HubConnection hubConnection;
    
        public event Action<string> OnBroadcastAction;
    
        private async Task ConnectAsync()
        {
            // Connect
    
            hubConnection.On<string>("Broadcast", OnBroadcast);
        }
    
        public async Task Send(string message)
        {
            await hubConnection.SendAsync("method", message);
        }
    
        private void OnBroadcast(string message)
        {
            OnBroadcastAction?.Invoke(message);
        }
    }
