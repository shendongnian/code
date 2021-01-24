     //Get Data From Client Provision
        public static void ProvisionClient()
        {
            SqlConnection serverConn = new SqlConnection(sServerConnection);
            SqlConnection clientConn = new SqlConnection(sClientConnection);
            //Drop scope_Info Table
            string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='scope_info') DROP table scope_info";
            clientConn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, clientConn);
            cmd.ExecuteScalar();
            clientConn.Close();
            List<string> tables = new List<string>();
            tables.Add("Demo"); // Add Tables in List
            tables.Add("Product");
            var scopeDesc = new DbSyncScopeDescription("MainScope");
            foreach (var tbl in tables) //Add Tables in Scope
            {
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable(tbl, clientConn));
            }
            SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc); //Provisioning
            //skip creating the user tables
            clientProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);
            //skip creating the change tracking tables
            clientProvision.SetCreateTrackingTableDefault(DbSyncCreationOption.Skip);
            //skip creating the change tracking triggers
            clientProvision.SetCreateTriggersDefault(DbSyncCreationOption.Skip);
            //skip creating the insert/update/delete/selectrow SPs including those for metadata
            clientProvision.SetCreateProceduresDefault(DbSyncCreationOption.Skip);
            //create new SelectChanges SPs for selecting changes for the new scope
            //the new SelectChanges SPs will have a guid suffix
            clientProvision.SetCreateProceduresForAdditionalScopeDefault(DbSyncCreationOption.Create);
            clientProvision.Apply();
        }
