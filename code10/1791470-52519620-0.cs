    using (var store = new DocumentStore() { Urls = new[] { "http://localhost:8080" } }.Initialize())
    {
      using (var bulk = store.BulkInsert("Sample"))
      {
        bulk.Store(new SampleDocument { Name = "Bulk.Store Null Id", Id = null }); // Sequential Id (I.E. SampleDocuments/1-A)
        bulk.Store(new SampleDocument { Name = "Bulk.Store Blank Id", Id = "" }); // Throws Error
        bulk.Store(new SampleDocument { Name = "Bulk.Store Guid Id", Id = Guid.NewGuid().ToString() }); // Guid Id
      }
      using (var session = store.OpenSession("Sample"))
      {
        session.Store(new SampleDocument { Name = "Session.Store Null Id", Id = null }); // Sequential Id (I.E. SampleDocuments/2-A)
        session.Store(new SampleDocument { Name = "Session.Store Empty Id", Id = "" }); // Guid Id
        session.Store(new SampleDocument { Name = "Session.Store Guid Id", Id = Guid.NewGuid().ToString() }); // Guid Id
        session.SaveChanges();
      }
    }
