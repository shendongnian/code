    // initiate the repos (use dependency injection instead of the ServiceLocator)
    var contentTypeRepository = ServiceLocator.Current.GetInstance<EPiServer.DataAbstraction.IContentTypeRepository>();
    var contentModelUsage = ServiceLocator.Current.GetInstance<IContentModelUsage>();
    var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
    var linkRepository = ServiceLocator.Current.GetInstance<IContentSoftLinkRepository>();
    
    // loading a block type
    var blockType = contentTypeRepository.Load(typeof(CodeBlock));
    
    // get usages, also includes versions
    IList<ContentUsage> usages = contentModelUsage.ListContentOfContentType(blockType);
    
    List<IContent> blocks = usages.Select(contentUsage =>
                            contentUsage.ContentLink.ToReferenceWithoutVersion())
                            .Distinct()
                            .Select(contentReference =>
                                    repository.Get<IContent>(contentReference)).ToList();
    
    
    var unusedBlocks = new List<IContent>();
    
    foreach (IContent block in blocks)
    {
        var referencingContentLinks = linkRepository.Load(block.ContentLink, true)
                                    .Where(link =>
                                            link.SoftLinkType == ReferenceType.PageLinkReference &&
                                            !ContentReference.IsNullOrEmpty(link.OwnerContentLink))
                                    .Select(link => link.OwnerContentLink);
    
        // if no links
        if (!referencingContentLinks.Any())
        {
            unusedBlocks.Add(block);
        }
    }
