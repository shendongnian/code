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
            task.Start();
            await task;
        }
    }
    public class Server
    {
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
                        await Task.Delay(1000);
                        StartReceiving(connectionString);
                    }
                });
        }
    }
    [TestFixture]
    public class TestServerRetry
    {
        [TestCase]
        public void TestRetry()
        {
            var server = new Server();
            server.StartReceiving("test connection");
            while (!server.IsStopped)
                Task.Delay(100).GetAwaiter().GetResult();
        }
    }
