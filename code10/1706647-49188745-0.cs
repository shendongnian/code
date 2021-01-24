    
    using (var materializer = system.Materializer())
    {
        var readJournal = PersistenceQuery.Get(system)
            .ReadJournalFor<SqlReadJournal>("akka.persistence.query.my-read-journal");
            
        var writer = asysem.ActorOf(CreateViewsActor.Props(), CreateViewsActor.GetActorName());
        readJournal
            .CurrentEventsByTag("MyEvents")
            .Collect(envelope => envelope.Event as MyEvent)
            .RunWith(Sink.ActorRefWithAck<MyEvent>(writer, 
                onInitMessage: CreateViewsActor.Init.Instance,
                ackMessage: CreateViewsActor.Ack.Instance,
                onCompleteMessage: CreateViewsActor.Done.Instance), materializer);
    }
