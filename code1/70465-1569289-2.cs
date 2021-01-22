    [TestMethod]
    public void Search_for_item_returns_one_result()
    {
        var searchService = CreateSearchServiceWithExpectedResults("test", 1);
        var eventAggregator = new SimpleEventAggregator();
        var searchViewModel = new SearchViewModel(searchService, 10, eventAggregator) { SearchText = searchText };
        var signal = new AutoResetEvent(false);
        var frame = new DispatcherFrame();
        // set the event to signal the frame
        eventAggregator.Subscribe(new ProgressCompleteEvent(), () =>
           {
               signal.Set();
               frame.Continue = false;
           });
        searchViewModel.Search(); // dispatcher call happening here
        Dispatcher.PushFrame(frame);
        signal.WaitOne();
        Assert.AreEqual(1, searchViewModel.TotalFound);
    }
