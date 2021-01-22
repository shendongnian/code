        [TestMethod]
        public void Search_for_item_returns_one_result()
        {
            const string searchText = "test";
            var searchService = CreateSearchServiceWithExpectedResults(searchText, 1);
            const int expectedTotal = 1;
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
            searchViewModel.Search(); // dispather call happening here
            Dispatcher.PushFrame(frame);
            signal.WaitOne();
            Assert.AreEqual(expectedTotal, searchViewModel.TotalFound);
        }
