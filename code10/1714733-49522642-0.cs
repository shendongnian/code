    public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info($"Webhook was triggered!");
    
        // Initialize the azure bot
        using (BotService.Initialize())
        {
            
            var resolveAssembly = Assembly.GetCallingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AzureModule(resolveAssembly));            
            builder.Register(c => new SettingsScorable(c.Resolve<IDialogTask>() ))
                           .As<IScorable<IActivity, double>>()
                           .InstancePerLifetimeScope();
            builder.Update(Conversation.Container);
    
    ...
    ...
        }
    }
