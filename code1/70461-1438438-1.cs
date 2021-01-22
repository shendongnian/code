    [TestMethod]
    public void DomainCollection_AddDomainObjectFromWorkerThread()
    {
     Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
     DispatcherFrame frame = new DispatcherFrame();
     IDomainCollectionMetaData domainCollectionMetaData = this.GenerateIDomainCollectionMetaData();
     IDomainObject parentDomainObject = MockRepository.GenerateMock<IDomainObject>();
     DomainCollection sut = new DomainCollection(dispatcher, domainCollectionMetaData, parentDomainObject);
    
     IDomainObject domainObject = MockRepository.GenerateMock<IDomainObject>();
    
     sut.SetAsLoaded();
     bool raisedCollectionChanged = false;
     sut.ObservableCollection.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
     {
      raisedCollectionChanged = true;
      Assert.IsTrue(e.Action == NotifyCollectionChangedAction.Add, "The action was not add.");
      Assert.IsTrue(e.NewStartingIndex == 0, "NewStartingIndex was not 0.");
      Assert.IsTrue(e.NewItems[0] == domainObject, "NewItems not include added domain object.");
      Assert.IsTrue(e.OldItems == null, "OldItems was not null.");
      Assert.IsTrue(e.OldStartingIndex == -1, "OldStartingIndex was not -1.");
      frame.Continue = false;
     };
    
     WorkerDelegate worker = new WorkerDelegate(delegate(DomainCollection domainCollection)
      {
       domainCollection.Add(domainObject);
      });
     IAsyncResult ar = worker.BeginInvoke(sut, null, null);
     worker.EndInvoke(ar);
     Dispatcher.PushFrame(frame);
     Assert.IsTrue(raisedCollectionChanged, "CollectionChanged event not raised.");
    }
