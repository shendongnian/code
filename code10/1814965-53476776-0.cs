    class Program
    {
        static void Main()
        {
            var msg = new MyMessageClass();
            msg.AddMessageAsync("content", TimeSpan.MaxValue, TimeSpan.MaxValue, new CancellationToken());
        }
    }
    class MyMessageClass
    {
        readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        private static Policy CheckRabbitMQPolicy(ILogger logger)
        {
            return Policy
                .Handle<Exception>()
                .WaitAndRetry(14, _ => TimeSpan.FromSeconds(2),
                    (exception, timeSpan, __) =>
                    {
                        logger.Warn(exception.Message);
                    });
        }
        public Task AddMessageAsync(string content,
            TimeSpan? timeToLive,
            TimeSpan? initialVisibilityDelay,
            CancellationToken cancellationToken)
        {
            var policyResult = CheckRabbitMQPolicy(_logger).ExecuteAndCapture(() => throw new Exception("Connection error"));
            return policyResult.Outcome == OutcomeType.Successful
                ? Task.CompletedTask
                : Task.FromException(policyResult.FinalException);
        }
    }
