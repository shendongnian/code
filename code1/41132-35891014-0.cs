    using System;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.IO;
    using System.Data.SqlClient;
    
    namespace MyNamespace
    {
        public partial class RunSqlScript : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var connectionString = @"your-connection-string";
                var pathToScriptFile = Server.MapPath("~/sql-scripts/") + "sql-script.sql";
                var sqlScript = File.ReadAllText(pathToScriptFile);
    
                using (var connection = new SqlConnection(connectionString))
                {
                    var server = new Server(new ServerConnection(connection));
                    server.ConnectionContext.ExecuteNonQuery(sqlScript);
                }
            }
        }
    }
