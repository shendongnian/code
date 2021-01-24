    // Summary:
    //     Sets the database initializer to use for the given context type. The database
    //     initializer is called when a the given System.Data.Entity.DbContext type is used
    //     to access a database for the first time. The default strategy for Code First
    //     contexts is an instance of System.Data.Entity.CreateDatabaseIfNotExists`1.
    //
    // Parameters:
    //   strategy:
    //     The initializer to use, or null to disable initialization for the given context
    //     type.
