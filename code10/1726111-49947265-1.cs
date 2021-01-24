        private List<string> GetSqlInstances(bool serverDiscovery = false)
        {
            if (serverDiscovery && InstancesLoaded) { return null; }
            var serverList = new List<string>();
            InstancesLoaded = true;
    
            var instance = SqlDataSourceEnumerator.Instance;
            var table = instance.GetDataSources();
            if (table.Rows == null) { return null; }
            foreach (DataRow row in table.Rows)
            {
                serverList.Add(row["ServerName"].ToString());
                if (!string.IsNullOrEmpty(row["InstanceName"].ToString()))
                    serverList.Add(row["ServerName"] + "\\" + row["InstanceName"]);
            }
    
            return serverList;
        }
    
        #region Database_Combobox
        
        private void cbxDatabaseName_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            cbxDatabaseName.Properties.Items.Clear();
            if (SqlHelper == null) { return; }
            try
            {
                var conStr = SqlHelper.GenerateSqlConnectionString
                (
                    cbxSQLInstances?.Text,
                    IntegratedSecurity,
                    string.Empty,
                    txtUserName?.Text,
                    txtPassword?.Text
                );
    
                var con = conStr?.ConnectionString != null ? new SqlConnection(conStr.ConnectionString) : null;
                
                if (con == null)
                    return;
    
                con.Open();
                var databases = con.GetSchema("Databases");
                if (databases?.Rows != null)
                {
                    foreach (DataRow row in databases.Rows)
                        cbxDatabaseName.Properties.Items.Add(row.Field<string>(@"database_name"));
                }
                cbxDatabaseName.ShowPopup();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
