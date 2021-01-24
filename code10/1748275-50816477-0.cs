    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string CmdString = "select ProductID from Product where ModelNo='" + 
        comboModel.SelectedItem.ToString() + "'";
        SqlCommand cmd = new SqlCommand(CmdString, connection);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable("Product");
        sda.Fill(dt1);
        foreach (DataRow dr in dt1.Rows)
        {
            txtProductID.Text = dr["ProductID"].ToString();
        }
    }
