    void OnApplesCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {    
      // Only add/remove items if already populated. 
      if (!IsPopulated)
        return;
    
      Apple apple;
    
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          apple = e.NewItems[0] as Apple;
          if (apple != null)
            AddViewModel(asset);
          break;
        case NotifyCollectionChangedAction.Remove:
          apple = e.OldItems[0] as Apple;
          if (apple != null)
            RemoveViewModel(apple);
          break;
      }
    
    }
