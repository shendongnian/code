    public class DefaultWebSocketWrapper : IWebSocket {
        private WebSocket webSocket;
        public DefaultWebSocketWrapper() {
            webSocket = new WebSocket("wss://localhost:443");
        }
        public event EventHandler OnOpen {
            add {
                webSocket.OnOpen += value;
            }
            remove {
                webSocket.OnOpen -= value;
            }
        }
        public void ConnectAsync() {
            webSocket.ConnectAsync();
        }
    }
