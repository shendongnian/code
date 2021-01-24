    public class WebsocketClient {
        private readonly IWebSocket connection;
        public WebsocketClient(IWebSocket connection) {
            this.connection = connection;
        }
        public event EventHandler Connected = delegate { };
        public void ConnectAsync() {
            connection.OnOpen += Connection_OnOpen;
            connection.ConnectAsync();
        }
        private void Connection_OnOpen(object sender, System.EventArgs e) {
            Connected.Invoke(this, new EventArgs());
        }
    }
