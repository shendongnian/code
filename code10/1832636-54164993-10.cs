    // set to number of shards in targeted indices
    var numberOfSlices = 4;
    
    var scrollAllObservable = client.ScrollAll<MyDocument>("30s", numberOfSlices);
    
    Exception exception = null;
    var manualResetEvent = new ManualResetEvent(false);
    
    var scrollAllObserver = new ScrollAllObserver<MyDocument>(
        onNext: s => 
        {
            var documents = s.SearchResponse.Documents;
            foreach (var document in documents)
            {
                // do something with this set of documents
            }
        },
        onError: e =>
        {
            exception = e;
            manualResetEvent.Set();
        },
        onCompleted: () => manualResetEvent.Set()
    );
    
    scrollAllObservable.Subscribe(scrollAllObserver);
    
    manualResetEvent.WaitOne();
    
    if (exception != null)
        throw exception;
