    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
        public void Exec(string script)
        {
            using (var conn = new SqlConnection(ConnString))
            {
                var server =  new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script, ExecutionTypes.ContinueOnError);
            }
        }
