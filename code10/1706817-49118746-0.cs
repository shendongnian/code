    List<SortDescription> SortDescriptions = new List<SortDescription>();
      
    SortDescriptions.Add(new SortDescription("Field1", ListSortDirection.Ascending));
    SortDescriptions.Add(new SortDescription("Field2", ListSortDirection.Ascending));
    SortDescriptions.Add(new SortDescription("Field3", ListSortDirection.Ascending));
    SortDescriptions.Add(new SortDescription("Field4", ListSortDirection.Ascending));
    
    
    CollectionViewSource collectionViewSource = new CollectionViewSource();
    public ICollectionView CollectionView
    {
    	get
        {
    		collectionViewSource.Source = <YourObservableCollection>;
            if (SortDescriptions != null)
            {
    			foreach (SortDescription sd in SortDescriptions)
    			{
    				collectionViewSource.View.SortDescriptions.Add(sd);
    			}
            }
            
    		collectionViewSource.View.Refresh();
            return collectionViewSource.View;        
    	}
    }
