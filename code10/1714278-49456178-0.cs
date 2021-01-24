    // initiate the repos (use dependency injection instead of the ServiceLocator)
    var contentTypeRepository = ServiceLocator.Current.GetInstance<EPiServer.DataAbstraction.IContentTypeRepository>();
    var contentModelUsage = ServiceLocator.Current.GetInstance<IContentModelUsage>();
    var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
    
    // loading a block type
    var blockType = contentTypeRepository.Load(typeof(ImportantNoticeBlock));
    
    // get usages, also includes versions
    IList<ContentUsage> usages = contentModelUsage.ListContentOfContentType(blockType);
    
    List<IContent> blocks = usages.Select(contentUsage => contentUsage.ContentLink.ToReferenceWithoutVersion())
                                   .Distinct()
                                   .Select(contentReference => repository.Get<IContent>(contentReference)).ToList();
    
    new FilterPublished().Filter(blocks);
    new FilterAccess().Filter(blocks);
    if (blocks.Any()) 
    {
        // ... do your stuff i.e.
        // var block = blocks.FirstOrDefault() as ImportantNoticeBlock;
    }
