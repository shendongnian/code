                reportDocument = new ReportDocument();
                reportDocument.Load(reportFileName);
                TableLogOnInfo tableLogOnInfo = ReportClass.GetSQLTableLogOnInfo(connectionProperties.DatabaseSource, connectionProperties.DatabaseName, connectionProperties.UserName, connectionProperties.Password);
                for (int i = 0; i < reportDocument.Database.Tables.Count; i++)
                {
                    Table table = reportDocument.Database.Tables[i];
                    table.ApplyLogOnInfo(tableLogOnInfo);
                }
     
         public static ConnectionInfo GetConnectionInfo(string serverName, string         databaseName, string userID, string password)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = serverName;
            connectionInfo.DatabaseName = databaseName;
            connectionInfo.UserID = userID;
            connectionInfo.Password = password;
            return connectionInfo;
        }
        public static TableLogOnInfo GetSQLTableLogOnInfo(string serverName, string databaseName, string userID, string password)
        {
            CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag connectionAttributes = new CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag();
            connectionAttributes.EnsureCapacity(11);
            connectionAttributes.Add("Connect Timeout", "15");
            connectionAttributes.Add("Data Source", serverName);
            connectionAttributes.Add("General Timeout", "0");
            connectionAttributes.Add("Initial Catalog", databaseName);
            connectionAttributes.Add("Integrated Security", false);
            connectionAttributes.Add("Locale Identifier", "1033");
            connectionAttributes.Add("OLE DB Services", "-5");
            connectionAttributes.Add("Provider", "SQLOLEDB");
            connectionAttributes.Add("Tag with column collation when possible", "0");
            connectionAttributes.Add("Use DSN Default Properties", false);
            connectionAttributes.Add("Use Encryption for Data", "0");
            DbConnectionAttributes attributes = new DbConnectionAttributes();
            attributes.Collection.Add(new NameValuePair2("Database DLL", "crdb_ado.dll"));
            attributes.Collection.Add(new NameValuePair2("QE_DatabaseName", databaseName));
            attributes.Collection.Add(new NameValuePair2("QE_DatabaseType", "OLE DB (ADO)"));
            attributes.Collection.Add(new NameValuePair2("QE_LogonProperties", connectionAttributes));
            attributes.Collection.Add(new NameValuePair2("QE_ServerDescription", serverName));
            attributes.Collection.Add(new NameValuePair2("SSO Enabled", false));
            ConnectionInfo connectionInfo = ReportClass.GetConnectionInfo(serverName, databaseName, userID, password);
            connectionInfo.Attributes = attributes;
            connectionInfo.Type = ConnectionInfoType.SQL;
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo = connectionInfo;
            return tableLogOnInfo;
        }
