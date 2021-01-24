    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)    
    {
      conn.Open();
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = "select * from tblmaster where Supplier = '" + comboBox3.SelectedItem.ToString() + "'";
      cmd.ExecuteNonQuery();
      DataTable dt = new DataTable();
      SqlDataAdapter Da = new SqlDataAdapter(cmd);
      Da.Fill(dt);
    
      comboBox5.Items.Clear();
      foreach(DataRow dr in dt.Rows) {
        comboBox5.Items.Add(dr["ProductCode"].ToString());
      }
    
      conn.Close();
    }
