    protected virtual void ExecuteSourceControlGet
        (IBuildMetaData metaData, IPackageTree tree)
    {
        if (metaData.RepositoryElementList.HasElements())
        {
            tree.DeleteWorkingDirectory();
    
            foreach (var element in metaData.RepositoryElementList)
                 element.PrepareRepository(tree, get).Export();    
        }
    
        if(metaData.ExportList.HasElements())
        {
            var init = true;
    
            foreach (var sourceControl in metaData.ExportList)
            {
                log.InfoFormat
		          ("\nHorn is fetching {0}.\n\n".ToUpper(), sourceControl.Url);
    
                get.From(sourceControl)
	 	          .ExportTo(tree, sourceControl.ExportPath, init);
    
                init = false;
            }
    
        }
    
        log.InfoFormat
	       ("\nHorn is fetching {0}.\n\n".ToUpper(), 
	           metaData.SourceControl.Url);
    
        get.From(metaData.SourceControl)
	       .ExportTo(tree);
    }
    //Credits goes to Jon Skeet...
    public static class CollectionExtensions
    {
        public static bool HasElements<T>(this ICollection<T> collection)
        {
            return collection != null && collection.Count != 0;
        }
    }
