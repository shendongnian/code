    public class AsyncServerDemo
    {
        private CancellationTokenSource cancel;
        private readonly TcpListenerEx listener;
        private Task WaitingForConnections;
        private Timer timerCallAcceptClients;
        public bool IsRunning { get; private set; }
        public AsyncServerDemo(int port)
        {
            cancel = new CancellationTokenSource();
            listener = new TcpListenerEx(IPAddress.Any, port);
        }
        private Task<string> WaitForMessageAsync(TcpClient client, CancellationToken token)
        {
            return Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                bool dataAvailable = false;
                while (!token.IsCancellationRequested)
                {
                    while (client.Client.Available > 0)
                    {
                        dataAvailable = true;
                        int buffered = client.Client.Available;
                        byte[] buffer = new byte[buffered];
                        client.Client.Receive(buffer);
                        sb.Append(Encoding.ASCII.GetString(buffer));
                    }
                    if (dataAvailable)
                    {
                        dataAvailable = false;
                        return sb.ToString();
                    }
                };
                return string.Empty; //timeout
            });
        }
        private Task AcceptClientAsync()
        {
            return Task.Factory.StartNew(async () =>
            {
                IsRunning = true && !cancel.IsCancellationRequested;
                while (!cancel.IsCancellationRequested)
                {
                    if (!listener.Pending())
                    {
                        continue;
                    }
                    TcpClient newClient = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    Stopwatch timeout = new Stopwatch();
                    timeout.Restart();
                    string message = await WaitForMessageAsync(newClient, new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token);
                    if (message != null)
                    {
                        //TODO: Message recieved
                    }
                    timeout.Stop();
                }
            });
        }
        public void Start()
        {
            listener.Start();
            timerCallAcceptClients = new Timer(new TimerCallback((state) =>
            {
                AcceptClientAsync();
            }), null, 0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
        }
        public async void Stop()
        {
            if (!IsRunning) return;
            using (cancel)
                cancel.Cancel();
            timerCallAcceptClients.Dispose();
            if (WaitingForConnections != null)
                await WaitingForConnections;
            cancel = null;
            listener.Stop();
            IsRunning = false;
            cancel = new CancellationTokenSource();
        }
    }
