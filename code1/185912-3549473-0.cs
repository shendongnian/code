    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    public class LoadStuff
    {
        ...
        public void LoadDatabase(string vDatabaseName)
        {
            using (var vSqlConnection = new SqlConnection(DatabaseConnectionString))
            {
                var vConnection = new ServerConnection(vSqlConnection);
                var vServer = new Server(vConnection);
                var vDatabase = vServer.Databases[vDatabaseName];
                var vTables = vDatabase.Tables;
            }
        }
    }
