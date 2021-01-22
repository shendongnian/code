    Server srv = new Server("serverNameHere");
    srv.ConnectionContext.AutoDisconnectMode = AutoDisconnectMode.NoAutoDisconnect;
    srv.ConnectionContext.LoginSecure = false; //if using username/password
    srv.ConnectionContext.Login = "username";
    srv.ConnectionContext.Password = "password";
    srv.ConnectionContext.Connect();
    Database db = srv.Databases["databaseNameHere"];
    foreach(StoredProcedure sp in db.StoredProcedures)
    {
        foreach(var param in sp.Parameters)
        {
            string paramName = param.Name;
            var dataType = param.DataType;
            object defaultValue = param.DefaultValue;
        }
    }
