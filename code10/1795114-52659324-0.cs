    DataTable dt = new DataTable();
    private void RefreshData()
    {
        dt.Clear();
        con.Open();
        Refresh();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select SupplierName from SuppTbl";
        cmd.ExecuteNonQuery();
        SqlDataAdapter dp = new SqlDataAdapter(cmd);
        dp.Fill(dt);
    	con.Close();
    	cmd.Dispose();
    }
    
    private void BindToComboBox()
    {
    	CmbSupp.DataSource = dt;
    	CmbSupp.ValueMember = "SupplierName";
    	CmbSupp.DisplayMember = "SupplierName";
    }
