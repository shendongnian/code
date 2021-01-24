        private void GetColumns(string Table)
        {
            listBox1.Items.Clear();
            string Query = "SELECT COLUMN_NAME FROM <YourDataBaseName>.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @Table";
            SqlDataReader reader = null;
            try
            {
                //Use your own connection string
                using (SqlConnection sqlConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=<YourDataBaseName>;Integrated Security=True"))
                using (SqlCommand command = new SqlCommand(Query, sqlConn))
                {
                    sqlConn.Open();
                    command.Parameters.AddWithValue("@Table", Table);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["COLUMN_NAME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            }
        }
