    [Test]
    public async Task DapperOutputClauseUsage()
    {
        // Arrange
        var conn = new SqlConnection("YourDatabaseConnectionString");
        await conn.OpenAsync();
        var ex = new ModelExample
        {
            code = "code",
            description = "description",
            site = "site"
        };
        // Act
        var result = await conn.QuerySingleAsync<ModelExample>(@"INSERT INTO ModelTable(code, description, site)
                                                                 OUTPUT INSERTED.*
                                                                 VALUES (@code, @description, @site)", ex);
        // Assert
        Assert.AreEqual(result.code, ex.code);
        Assert.AreEqual(result.description, ex.description);
        Assert.AreEqual(result.site, ex.site);
    }
    public class ModelExample
    {
        public string code { get; set; }
        public string description { get; set; }
        public string site { get; set; }
    }
