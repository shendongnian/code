            private void fillcmbOperator()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.LazerMaintenance_Conn))
            {
                try
                {
                    string query = "SELECT Operators.Initials, Operators.Name " +
                           "FROM Operators WHERE Operators.Active_Ind = 'True'";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "dsOperators");
                    cmbOperator.ValueMember = "Initials";
                    cmbOperator.DisplayMember = "Name";
                    cmbOperator.DataSource = ds.Tables["dsOperators"];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured! : " + ex);
                }
            }
        }
