    public void AddThing(IThing thing)
    {
        //...
        (thing.Values as INotifyCollectionChanged).CollectionChanged += this.HandleThingCollectionChanged;
    }
    
    public void RemoveThing(IThing thing)
    {
        //...
        (thing.Values as INotifyCollectionChanged).CollectionChanged -= this.HandleThingCollectionChanged;
    }
