    string script = File.ReadAllText("script.sql");
    Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server();
    server.ConnectionContext.LoginSecure = false;
    server.ConnectionContext.Login = "user";
    server.ConnectionContext.Password = "pass";
    server.ConnectionContext.ServerInstance = "instance";
    server.Databases["master"].ExecuteNonQuery(script);
