    private void btnid_Click(object sender, EventArgs e)
    {
        int max = 0;
        cn.Open();
        cmd = new SqlCommand("select Max(Id) from AddressBook");
        try
        {
            int max = (int)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    
        if ((max == 0))
            txtid.Text = "GPSC0000001";
        else
        {
            int TotalCodeWithoutLable = max.ToString().Length - 6;
            int OldNum = max.ToString().Substring(max.ToString().Length - TotalCodeWithoutLable);
            txtid.Text = "GPSC" + StringFormat(OldNum + 1, "0000000").ToString;
        }
    }
