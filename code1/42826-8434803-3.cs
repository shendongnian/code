    [TestMethod]
    public void TestShimmyAddRange()
    {
      int colChangedEvents = 0;
      int propChangedEvents = 0;
      var collection = new ShimmyObservableCollection<object>();
      collection.CollectionChanged += (sender, e) => { colChangedEvents++; };
      (collection as INotifyPropertyChanged).PropertyChanged += (sender, e) => { propChangedEvents++; };
      collection.AddRange(new[]{
        new object(), new object(), new object(), new object()}); //4 objects at once
      Assert.AreEqual(1, colChangedEvents);  //great, just one!
      Assert.AreEqual(2, propChangedEvents); //fails, no events :(
    }
