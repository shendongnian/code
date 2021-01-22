    private void OnClicked_RefreshDataSources(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            DataTable dt = SmoApplication.EnumAvailableSqlServers(false);
            uxDataSource.Items.Clear();
            foreach (DataRow row in dt.Rows) {
                uxDataSource.Items.Add(row["Name"]);
            }
            if (dt.Rows.Count > 0) {
                uxDataSource.SelectedIndex = 0;
            }
            Cursor = Cursors.Default;
        }
        private void OnSelectedIndexChanged_PopulateDatabases(object sender, EventArgs e) {
            ConnectionString.DataSource = uxDataSource.SelectedItem.ToString();
            Server server = new Server(uxDataSource.SelectedItem.ToString());
            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Program.DesktopService.AccountName;
            uxInitialCatalog.Items.Clear();
            try {
                foreach (Database db in server.Databases) {
                    uxInitialCatalog.Items.Add(db.Name);
                }
                if (server.Databases.Count > 0) {
                    uxInitialCatalog.SelectedIndex = 0;
                }
            }
            catch {
                MessageBox.Show("You do not have access to this server.", "Sql Connection", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                uxInitialCatalog.Items.Clear();
            }
        }
