    //Wrong variant
    IDocumentStore store = new DocumentStore()
    {
        Urls = new string[] { Host }, /*Database = "testdb"*/
    }
    using (IDocumentSession session = store.OpenSession(dbName))
    {
        //some code
    }
    //Good variant
    IDocumentStore store = new DocumentStore()
    {
         Urls = new string[] { Host }, Database = "testdb"
    }
    using (IDocumentSession session = store.OpenSession())
    {
         //some code
    }
