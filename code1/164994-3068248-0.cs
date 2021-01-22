    public class Client
    {
        [Export("PluginDelegate")]
        IPlugin GetPlugin()
        {
            return new SamplePlugin();
        }
        [Import]
        public INotificationService NotificationService { get; set; }
    }
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ClientNotificationService : INotificationService
    {
        [Import("PluginDelegate")] Func<IPlugin> PluginDelegate;
    }
