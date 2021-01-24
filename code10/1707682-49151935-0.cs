    string connectionString = 
           VendorFinder.Properties.Settings.Default.VendorFinderConnectionString;
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT PartnerName, Response FROM 
        dbo.ResponseMessage", con);
        con.Open();
        cmd.CommandType = CommandType.Text;
        dr = cmd.ExecuteReader();
		if(dr.HasRows)
		{
			while (dr.Read())
			{
				comboBox3.Items.Add(dr.GetValue(0));
				richTextBox1.Text = dr["Response"].ToString();
			}
 			dr.Close();
		}
		else
        {
            MessageBox.Show("No Record Found. Please try again", "Vendor 
            Finder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
