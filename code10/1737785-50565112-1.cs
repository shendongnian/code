    switch (workerType)
    {
        case "worker1":
            var context1 = new SomeConnectorContext(...);
            Container.RegisterConditional<SomeConnector>(
                Lifestyle.Transient.CreateRegistration(
                () => new SomeConnector(context1), container),
                c => c.Consumer.Target.Name == "dataConnector");
            var context2 = new SomeConnectorContext(...);
            Container.RegisterConditional<SomeConnector>(
                Lifestyle.Transient.CreateRegistration(
                () => new SomeConnector(context2), container),
                c => c.Consumer.Target.Name == "transactionConnector");
                
            Container.Register<IWorker, Worker1>();
            break;
        case "worker2":
            Container.Register<IConnectorContext>(new SomeConnectorContext(...));
            Container.Register<IConnector, SomeConnector>();
            Container.Register<IWorker, Worker2>();
            break;
    }
