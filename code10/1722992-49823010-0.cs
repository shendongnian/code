    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ContentEventHandler : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var eventRegistry = ServiceLocator.Current.GetInstance<IContentEvents>();
            eventRegistry.PublishingContent += OnPublishingContent;
        }
        private void OnPublishingContent(object sender, ContentEventArgs e)
        {
            if (e.Content.Name.Contains("BlockType"))
            {
                e.Content.Name = e.Content.Name.Replace("BlockType", "NewName");
            }
        }
    }
    
