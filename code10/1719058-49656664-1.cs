    var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
    if (page != null && page.ContentArea != null && page.PrimaryComponentArea.Items.Any())
    {
        foreach (var contentItem in page.PrimaryComponentArea.Items)
        {
            var item = contentLoader.Get<YOUR_CONTENT_TYPE>(contentItem.ContentLink);
            // do your stuff
        }
    }
