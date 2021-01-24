    public MainService(IConfiguration configuration, IApplicationLifetime appLifetime, IServiceProvider serviceProvider)
    {
        this.configuration = configuration;            
        messageQueue = serviceProvider.GetServices<IMessageQueue>();
        messageQueueSL = serviceProvider.GetServices<IMessageQueue>();
        messageQueueSLProcess = serviceProvider.GetServices<IMessageQueue>();
        this.appLifetime = appLifetime;
    }
