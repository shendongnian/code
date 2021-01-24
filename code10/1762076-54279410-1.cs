    var builder = new DbContextOptionsBuilder<MyContext>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    builder.UseSqlServer(connectionString);
    
    // the following line is the one that prevents client side evaluation
    builder.ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning));
