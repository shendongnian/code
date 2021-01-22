    [TestFixture("System.Data.SqlClient",
      "Server=(local)\\SQLEXPRESS;Initial Catalog=MyTestDatabase;Integrated Security=True;Pooling=False"))]
    [TestFixture("System.Data.SQLite", "Data Source=MyTestDatabase.s3db")])]
    internal class MyDataAccessLayerIntegrationTests
    {
        MyDataAccessLayerIntegrationTests(
            string dataProvider,
            string connectionString)
        {
            ...
        }
    }
