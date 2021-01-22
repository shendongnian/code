            try
            {
                this.databasesComboBox.Items.Clear();
                this.databasesComboBox.Items.Add("Please wait while loading available databases...");
                DataTable tables = new DataTable("Tables");
                using (IDbConnection connection = this.GetConnection())
                {
                    IDbCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM sys.Databases";
                    connection.Open();
                    tables.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
                }
                this.databasesComboBox.Items.Clear();
                foreach (DataRow row in tables.Rows)
                    this.databasesComboBox.Items.Add(row[0].ToString());
            }
            catch (SqlException)
            {
                this.databasesComboBox.Items.Clear();
                this.databasesComboBox.Items.Add("Connection error. Check server & credentials");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading available databases: " + ex.ToString());
            }
            finally
            {
                DatabaseListCreating = false;
            }
