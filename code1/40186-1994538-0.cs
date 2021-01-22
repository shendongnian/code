    using (var trans = _session.BeginTransaction(IsolationLevel.ReadUncommitted))
    {
        new PersistenceSpecification<Event>(_session)
            .CheckProperty(p => p.StartTime, new DateTime(2010, 1, 1))
            .VerifyTheMappings();
        trans.Rollback();
    }
