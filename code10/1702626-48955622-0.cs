    using (DocumentClient destClient = new DocumentClient(destCollInfo.Uri, destCollInfo.MasterKey))
    {
        DocumentFeedObserverFactory docObserverFactory = new DocumentFeedObserverFactory(destClient, destCollInfo);
    
        ChangeFeedEventHost host = new ChangeFeedEventHost(hostName, documentCollectionLocation, leaseCollectionLocation, feedOptions, feedHostOptions);
        await host.RegisterObserverFactoryAsync(docObserverFactory);
    
    	// This is where I thought I need to block this thread indeterminately.
        Console.WriteLine("Running... Press enter to stop.");
        Console.ReadLine();
    
        await host.UnregisterObserversAsync();
    }
