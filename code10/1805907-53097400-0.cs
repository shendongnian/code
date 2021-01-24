    public void deldata()
        {
            foreach (DataGridViewRow dr in dataGrid1.SelectedRows)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DDBULK10\SQLEXPRESS;Initial Catalog=MasterList; Integrated Security = True";
                if (dr.Index > 0)
                {
                    int selectedIndex = dataGrid1.SelectedRows[0].Index;
                    int rowID = int.Parse(dataGrid1[0, selectedIndex].Value.ToString());
                    string sql = "DELETE FROM ActiveUser WHERE EmpId = @EmpId";
                    SqlCommand deleteRecord = new SqlCommand();
                    deleteRecord.Connection = con;
                    deleteRecord.CommandType = CommandType.Text;
                    deleteRecord.CommandText = sql;
                    SqlParameter RowParameter = new SqlParameter();
                    RowParameter.ParameterName = "@EmpId";
                    RowParameter.SqlDbType = SqlDbType.Int;
                    RowParameter.IsNullable = false;
                    RowParameter.Value = rowID;
                    deleteRecord.Parameters.Add(RowParameter);
                    deleteRecord.Connection.Open();
                    deleteRecord.ExecuteNonQuery();
                    //deleteRecord.Connection.Close();
                    MessageBox.Show("Record Successfully Deleted");
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Refresh();
                }
            }
        }
        public void showdata()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from ActiveUser", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGrid1.DataSource = dt;
        }
