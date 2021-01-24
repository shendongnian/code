    public class ClientExDemo
    {
        private Task<string> WaitForMessage;
        private NetworkStream currentStream;
        private CancellationTokenSource messageToken;
        public EventHandler<ClientEx> OnServerFound;
        public TcpClient Connection;
        public EventHandler<string> OnMessage;
        public async Task StartListenAsync(CancellationTokenSource token = null)
        {
            if (token == null)
                messageToken = new CancellationTokenSource();
            else
                messageToken = token;
            currentStream = Connection.GetStream();
            string message = "";
         
            if (message.Length > 0)
                OnMessage?.Invoke(this, message);
            if (!messageToken.IsCancellationRequested)
            {
                await StartListenAsync(token);
            }
            Timeout();
        }
        protected virtual void Timeout()
        {
        }
        public async Task WaitForServerAsync(string ip, int port)
        {
            do
            {
                try
                {
                    await Connection.ConnectAsync(ip, port);
                }
                catch (SocketException x)
                {
         
                }
                await Task.Delay(50);
            } while (!Connection.Connected);
        }
        public void StopListen()
        {
            using (messageToken)
            {
                messageToken.Cancel();
            }
            try
            {
                WaitForMessage.GetAwaiter().GetResult();
            }
            catch (AggregateException)
            {
            }
            currentStream.Close();
            messageToken = null;
            currentStream = null;
            WaitForMessage = null;
        }
        public ClientExDemo()
        {
            Connection = new TcpClient();
            OnServerFound += ServerFound;
        }
        private void ServerFound(object sender, ClientEx args)
        {
         
        }
        public void Send(string message)
        {
            Connection.Client.Send(Encoding.ASCII.GetBytes(message));
        }
       
    }
