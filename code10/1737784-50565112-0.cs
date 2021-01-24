    switch (workerType)
    {
        case "worker1":
            var context1 = new SomeConnectorContext(...);
            var context2 = new SomeConnectorContext(...);
            
            Container.Register<IWorker>(() => Worker1(
                new SomeConnector(context1),
                new SomeConnector(context2)));
            break;
                
        case "worker2":
            var context1 = new SomeConnectorContext(...);
            
            Container.Register<IWorker>(() => Worker1(
                new SomeConnector(context1)));
            break;
    }
