    // ServiceLocator as example, use dependency injection!
    var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
    
    // Get all CodeBlock's from the contentarea
    IEnumerable<CodeBlock> items = currentPage.ContentArea?.Items?
        .Where(block => block.GetContent() is CodeBlock) // validate type
        .Select(block => contentLoader.Get<CodeBlock>(block.ContentLink));
    // Run a where on a specific property on the blocks
    IEnumerable<CodeBlock> items = currentPage.ContentArea?.Items?
        .Where(block => block.GetContent() is CodeBlock) // validate type
        .Select(block => contentLoader.Get<CodeBlock>(block.ContentLink))
        .Where(block => block.Tags.Contains("Episerver"));
