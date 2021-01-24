        //Set Data To Server Provision
        public static void ProvisionServer()
        {
            SqlConnection serverConn = new SqlConnection(sServerConnection);
            string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='scope_info') DROP table scope_info";
            serverConn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, serverConn);
            cmd.ExecuteScalar();
            serverConn.Close();
            List<string> tables = new List<string>();
            tables.Add("Demo");
            tables.Add("Product");
            var scopeDesc = new DbSyncScopeDescription("MainScope");
            foreach (var tbl in tables)
            {
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable(tbl, serverConn));
            }
            SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc); // Create Provision From All Tables
            //skip creating the user tables
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);
            //skip creating the change tracking tables
            serverProvision.SetCreateTrackingTableDefault(DbSyncCreationOption.Skip);
            //skip creating the change tracking triggers
            serverProvision.SetCreateTriggersDefault(DbSyncCreationOption.Skip);
            //skip creating the insert/update/delete/selectrow SPs including those for metadata
            serverProvision.SetCreateProceduresDefault(DbSyncCreationOption.Skip);
            serverProvision.Apply();
        }
