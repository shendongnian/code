    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        public Form1()
        {
            InitializeComponent();
        }
        private void Producer()
        {
            var id = 0;
            while (true )
            {
                CommandPool.Commands.Add($"Command {++id}");
                Thread.Sleep(500);
                if (_cts.IsCancellationRequested)
                {
                    CommandPool.Commands.CompleteAdding();
                    break;
                }
            }
            Debug.WriteLine("Producer finished");
        }
        private void Start(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            CommandsComsumer.Run(_cts.Token);
            Task.Run(() => Producer(), _cts.Token);
        }
        private void Stop(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
    }
    public static class CommandPool
    {
        public static readonly BlockingCollection<string> Commands = new BlockingCollection<string>();
    }
    public static class CommandsComsumer
    {
        private static CancellationToken _token;
        public static Task Run(CancellationToken cancellationToken)
        {
            _token = cancellationToken;
            return Task.Factory.StartNew(Consume, cancellationToken);
        }
        private static void Consume()
        {
            foreach (var cmd in CommandPool.Commands.GetConsumingEnumerable())
            {
                Debug.WriteLine(cmd);
            }
            Debug.WriteLine("Consumer finished");
        }
    }
