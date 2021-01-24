    class Program
    {
        static void Main(string[] args)
        {
            // Begin composition root
            var containerBuilder = new ContainerBuilder();
            var config1 = new ConsumerConfig();
            var config2 = new DispatcherConfig();
            containerBuilder.RegisterInstance(config1).AsSelf().SingleInstance();
            containerBuilder.RegisterInstance(config2).AsSelf().SingleInstance();
            containerBuilder.RegisterGeneric(typeof(MessageQueue<>))
                .As(typeof(IMessageQueue<>)).SingleInstance();
            containerBuilder.RegisterGeneric(typeof(MessageService<>))
                .As(typeof(IMessageService<>)).SingleInstance();
            containerBuilder.RegisterType<TopLevelMessageConsumer>()
                .AsSelf().SingleInstance();
            containerBuilder.RegisterType<TopLevelMessageDispatcher>()
                .AsSelf().SingleInstance();
            var container = containerBuilder.Build();
            // End composition root
            var dispatcher = container.Resolve<TopLevelMessageDispatcher>();
            var consumer = container.Resolve<TopLevelMessageConsumer>();
        }
    }
