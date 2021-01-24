    public class Receiver
    {
        public async Task StartReceiving(string connectionString)
        {
            var task = new Task(() =>
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
                .ContinueWith(c =>
                {
                    if (c.IsFaulted)
                    {
                        var n = Process.GetCurrentProcess().Threads.Count;
                        Task.Delay(1000);
                        StartReceiving(connectionString);
                    }
                });
        }
    }
    [TestFixture]
    public class TestServer
    {
        [TestCase]
        public void TestRetry()
        {
            var server = new Server();
            var serverTask = new Task(() => server.StartReceiving("test connection"));
            serverTask.Start();
            while (!server.IsStopped)
                Task.Delay(100);
        }
    }
