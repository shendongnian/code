    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    public class LoadStuff
    {
        string mDatabaseConnectionString = "Something";
        ...
        public void LoadDatabase(string tDatabaseName)
        {
            using (var vSqlConnection = new SqlConnection(mDatabaseConnectionString))
            {
                var vConnection = new ServerConnection(vSqlConnection);
                var vServer = new Server(vConnection);
                var vDatabase = vServer.Databases[tDatabaseName];
                var vTables = vDatabase.Tables;
            }
        }
    }
