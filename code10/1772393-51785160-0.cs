    public static class SomeLogger
    {
        private static readonly BufferBlock<LogObject> _buffer = new BufferBlock<LogObject>();
        private static Task _consumer;
        private static CancellationTokenSource _cts;
        public static void Start()
        {
            if (_cts != null && !_cts.IsCancellationRequested) return;
            _cts = new CancellationTokenSource();
            _consumer = ConsumeAsync(_buffer, _cts.Token);
        }
        public static void Stop()
        {
            _cts.Cancel();
        }
        public static void AddToQueue(LogObject log)
        {
            SendToBuffer(_buffer, log);
        }
        private static void SendToBuffer(ITargetBlock<LogObject> target, LogObject log)
        {
            target.Post(log);
        }
        private static async Task ConsumeAsync(IReceivableSourceBlock<LogObject> source, CancellationToken cancellationToken)
        {
            while (await source.OutputAvailableAsync(cancellationToken))
            {
                var log = await source.ReceiveAsync();
                // do some stuff
            }
        }
