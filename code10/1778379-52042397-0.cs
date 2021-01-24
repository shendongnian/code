    public class CustomBotStore : IBotDataStore<BotData>
    {
        private IBotDataStore<BotData> _store;
        public CustomBotStore()
        {
            string connString = ConfigurationManager.ConnectionStrings["BotState"].ConnectionString;
            _store = new TableBotDataStore(connString, "testbotdata"); // requires Microsoft.BotBuilder.Azure Nuget package 
        }
        public Task<bool> FlushAsync(IAddress key, CancellationToken cancellationToken)
        {
            return _store.FlushAsync(key, cancellationToken);
        }
        public Task<BotData> LoadAsync(IAddress key, BotStoreType botStoreType, CancellationToken cancellationToken)
        {
            return _store.LoadAsync(key, botStoreType, cancellationToken);
        }
        public Task SaveAsync(IAddress key, BotStoreType botStoreType, BotData data, CancellationToken cancellationToken)
        {
            return _store.SaveAsync(key, botStoreType, data, cancellationToken);
        }
    }
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Conversation.UpdateContainer(
            builder =>
            {
                builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));
                
                builder.Register(c => new CustomBotStore())
                    .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                    .AsSelf()
                    .InstancePerLifetimeScope();
            });
        }
    }
