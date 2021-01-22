    public void AddThing(IThing thing)
    {
        //...
        INotifyCollectionChanged thingCollection = thing.Values;
        thingCollection.CollectionChanged += this.HandleThingCollectionChanged;
    }
    
    public void RemoveThing(IThing thing)
    {
        //...
        INotifyCollectionChanged thingCollection = thing.Values;
        thingCollection.CollectionChanged -= this.HandleThingCollectionChanged;
    }
