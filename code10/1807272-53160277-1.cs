    public static Task Run(Message message, ILogger logger)
    {
        using (AsyncScopedLifestyle.BeginScope(Main.Container)
        {
            Main.Container.GetInstance<ProxyLogger>().Logger = logger;
            var controller = Main.Container.GetInstance<ConsumerController>();
            return controller.Execute(message);
        }
    }
