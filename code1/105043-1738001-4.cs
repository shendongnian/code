public static class ConnectionFactory
{
    public static IDbConnection GetConnection()
    {
        return GetConnection(ConfigurationManager.ConnectionString["GeoDataConnection"]);
    }
    public static IDbConnection GetConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
}
