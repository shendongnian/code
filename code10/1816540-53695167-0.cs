    public class MyHubHelper : IMyHubHelper
    {
        private readonly IHubContext<MySignalRHub> _hubContext;
        public MyHubHelper(IHubContext<MySignalRHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public void SendData(String data)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", data);
        }
    }
