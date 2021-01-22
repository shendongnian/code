    [Test]
    public void TestAddRangeWhileBoundToListCollectionView()
    {
        int collectionChangedEventsCounter = 0;
        int propertyChangedEventsCounter = 0;
        var collection = new ObservableRangeCollection<object>();
        collection.CollectionChanged += (sender, e) => { collectionChangedEventsCounter++; };
        (collection as INotifyPropertyChanged).PropertyChanged += (sender, e) => { propertyChangedEventsCounter++; };
        var list = new ListCollectionView(collection);
        collection.AddRange(new[] { new object(), new object(), new object(), new object() });
        Assert.AreEqual(4, collection.Count);
        Assert.AreEqual(1, collectionChangedEventsCounter);
        Assert.AreEqual(2, propertyChangedEventsCounter);
    }
