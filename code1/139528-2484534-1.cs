        public static SqlConnection SqlConnectOneTime(string varSqlConnectionDetails) {
            SqlConnection sqlConnection = new SqlConnection(varSqlConnectionDetails);
            try {
                sqlConnection.Open();
            } catch {
                DialogResult result = MessageBox.Show(new Form {
                                                                   TopMost = true
                                                               }, "No connection to database. Do you want to retry?", "No connection (000001)", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (result == DialogResult.No) {
                    if (Application.MessageLoop) {
                        // Use this since we are a WinForms app
                        Application.Exit();
                    } else {
                        // Use this since we are a console app
                        Environment.Exit(1);
                    }
                } else {
                    sqlConnection = SqlConnectOneTime(varSqlConnectionDetails);
                }
            }
            return sqlConnection;
        }
