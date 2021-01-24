    using SuperSocket.SocketBase;
    using SuperWebSocket;
    using System;
    using System.Net;
    using System.Net.Sockets;
    namespace Jees.Library.WebSocket
    {
        public class WebSocket
        {
            WebSocketServer appServer;
            public event EventHandler ServerStarted;
            public event EventHandler ServerStopped;
            public event EventHandler MessageReceived;
            public string IP { get; } = string.Empty;
            public int Port { get; } = 1337; //change this to the port you want to use
            public WebSocket() => this.IP = GetLocalIPAddress(); //or set it manually
            public void Start()
            {
                appServer = new WebSocketServer();
                if (!appServer.Setup(this.IP, this.Port))
                {
                    this.OnServerStarted(new WebSocketServerEventArgs(false));
                    return;
                }
                /* start listening */
                appServer.NewMessageReceived += new SessionHandler<WebSocketSession, string>(AppServer_NewMessageReceived);
                if (appServer.Start())
                    this.OnServerStarted(new WebSocketServerEventArgs(true));
                else
                {
                    this.OnServerStarted(new WebSocketServerEventArgs(false));
                    appServer = null;
                    appServer.Dispose();
                }
            }
            public void Stop()
            {
                if (appServer != null)
                {
                    appServer.Stop();
                    this.OnServerStopped(new EventArgs());
                    appServer = null;
                    appServer.Dispose();
                }
            }
            private void AppServer_NewMessageReceived(WebSocketSession session, string message)
            {
                this.OnMessageReceived(new MessageReceivedEventArgs(message, session));
            }
            protected virtual void OnMessageReceived(EventArgs e) => this.MessageReceived?.Invoke(this, e);
            protected virtual void OnServerStarted(EventArgs e) => this.ServerStarted?.Invoke(this, e);
            protected virtual void OnServerStopped(EventArgs e) => this.ServerStopped?.Invoke(this, e);
            private string GetLocalIPAddress()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
        }
        public class WebSocketServerEventArgs : EventArgs
        {
            public WebSocketServerEventArgs(bool success) => this.Success = success;
            public bool Success { get; }
        }
        public class MessageReceivedEventArgs : EventArgs
        {
            public MessageReceivedEventArgs(string message, WebSocketSession session)
            {
                this.Message = message;
                this.Session = session;
            }
            public string Message { get; }
            public WebSocketSession Session { get; }
        }
    }
