    [InitializableModule]
    [ModuleDependency(typeof(InitializationModule))]
    public class ModelDefaultValuesInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.CreatedContent += MediaBlocksDefaultValues;
        }
        private void MediaBlocksDefaultValues(object sender, ContentEventArgs e)
        {
            PopulateAssetURL(e);
        }
        /// <summary>
        /// Get the URL path of the uploaded asset and set it to the SrcUrl field which is easily visible to editors
        /// </summary>
        /// <param name="e"></param>
        private void PopulateAssetURL(ContentEventArgs e)
        {
            var mediaTypeBlock = e.Content as PdfFile;
            if (mediaTypeBlock != null)
            {
                string result = ServiceLocator.Current.GetInstance<UrlResolver>().GetUrl(mediaTypeBlock.ContentLink);
                if (!string.IsNullOrEmpty(result))
                {
                    var srvcLoc = ServiceLocator.Current.GetInstance<IContentRepository>();
                    var contentClone = mediaTypeBlock.CreateWritableClone() as PdfFile;
                    contentClone.SrcUrl = result;
                    srvcLoc.Save(contentClone, SaveAction.Publish, EPiServer.Security.AccessLevel.Administer);
                }
            }            
        }
        public void Uninitialize(InitializationEngine context)
        {
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.CreatedContent -= MediaBlocksDefaultValues;
        }
    }
