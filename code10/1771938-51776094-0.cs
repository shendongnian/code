    public class ThrowVoid
    {
        public string Content { get; set; }
    }
    public class TestMqService : Service
    {
        public void Any(ThrowVoid request)
        {
            throw new InvalidOperationException("this is an invalid operation");
        }
    }
    public class AppHost : AppSelfHostBase
    {
         public AppHost(Func<IMessageService> createMqServerFn)
            : base(nameof(TestMqService), typeof(TestMqService).Assembly) {}
        public override void Configure(Container container)
        {
            var mqServer = new RabbitMqServer { RetryCount = 1 };
            container.Register<IMessageService>(c => mqServer);
            mqServer.RegisterHandler<ThrowVoid>(ExecuteMessage);
            AfterInitCallbacks.Add(appHost => mqServer.Start());
        }
    }
