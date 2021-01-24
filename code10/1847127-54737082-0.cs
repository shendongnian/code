    private string ReadSqlFile(string relativePath)
    {
        var path = Path.Combine(AppContext.BaseDirectory, relativePath);
        return File.ReadAllText(path);
    }
    
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        //some migrations methods
        var script = ReadSqlFile("Migrations/DataMigration/AddNewCountryFieldToStudent.sql");
        migrationBuilder.Sql(script);
    }
