    [ServiceConfiguration(typeof(IPublishingContent))]
    public class PublishingStandardPage : PublishingContentBase<StandardPage>
    {
        protected override void PublishingContent(object sender, TypedContentEventArgs e)
        {
            // Here you can access the standard page
            StandardPage standardPage = e.Content;
        }
    }
