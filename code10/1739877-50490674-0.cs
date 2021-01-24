    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Add(new RegisterJsonValueFunctionConvention());
    }
    
    // Than define your function
    [DbFunction("CodeFirstDatabaseSchema", "JSON_VALUE")]
    public static string JsonValue(string expression, string path)
    {
        throw new NotSupportedException();
    }
