    public void AddThing(IThing thing)
    {
        //...
        thing.Values.RegisterCollectionChanged(this.HandleThingCollectionChanged);
    }
    
    public void RemoveThing(IThing thing)
    {
        //...
        thing.Values.UnregisterCollectionChanged(this.HandleThingCollectionChanged);
    }
