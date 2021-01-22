internal static class ConnectionUtility
{
    internal static IDbConnection GetConnection()
    {
        return GetConnection(ConfigurationManager.ConnectionString["GeoDataConnection"]);
    }
    internal static IDbConnection GetConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
}
