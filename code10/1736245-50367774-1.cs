    private void btnid_Click(object sender, EventArgs e)
    {
        string GetCode = "0";
        cn.Open();
        cmd = new SqlCommand("select * from AddressBook order by Id desc");
        try
        {
            dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (dr.Read())
                GetCode = dr["Id"].ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        if (string.Equals(GetCode, "0"))
            txtid.Text = "GPSC0000001";
        else
        {
            int TotalCodeWithoutLable = GetCode.Length - 6;
            int OldNum = GetCode.Substring(GetCode.Length - TotalCodeWithoutLable);
            txtid.Text = "GPSC" + StringFormat(OldNum + 1, "0000000").ToString;
        }
    }
