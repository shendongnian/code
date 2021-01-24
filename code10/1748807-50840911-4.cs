    public class Receiver
    {
        public async Task StartReceiving(string connectionString)
        {
            var task = Task.Run(() =>
            {
                try
                {
                    throw new Exception("connection lost");
                }
                catch (Exception)
                {
                    /* log the exception, or something */
                    throw;
                }
            });
            await task;
        }
    }
    public class Server
    {
        ILog log = LogManager.GetLogger<Server>();
        public bool IsStopped { get; private set; } = false;
        private Receiver _receiverHost = new Receiver();
        public void StartReceiving(string connectionString)
        {
            _receiverHost
                .StartReceiving(connectionString)
                .ContinueWith(async c =>
                {
                    if (c.IsFaulted)
                    {
                        var n = Process.GetCurrentProcess().Threads.Count;
                        var timestamp = DateTime.UtcNow;
                        await Task.Delay(1000);
                        log.Debug($"Task Delay: {(DateTime.UtcNow - timestamp).TotalSeconds} seconds");
                        StartReceiving(connectionString);
                    }
                });
        }
    }
    [TestFixture]
    public class TestServerRetry
    {
        [TestCase]
        public async Task TestRetry()
        {
            var server = new Server();
            server.StartReceiving("test connection");
            while (!server.IsStopped)
                await Task.Delay(100);
        }
    }
