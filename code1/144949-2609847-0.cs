    var connection = GetUnOpenedSqlConnection();       // Any connection that inherits
                                                       // from DbConnection is fine.
    var builder = new ContextBuilder<ObjectContext>(); // I actually had my own class
                                                       // that inherits from 
                                                       // ObjectContext, but that was 
                                                       // not the issue (I checked).
    builder.Configurations.Add(EntryConfiguration);    // EntryConfiguration is the 
                                                       // class in the question
    var context = builder.Create(connection);
    if (context.DatabaseExists())
    { context.DeleteDatabase(); }
    context.CreateDatabase();
