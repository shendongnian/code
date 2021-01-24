     private void exportKey_Click(object sender, EventArgs e)
        {
            //adding into local database
            //excludes adding licensekeys
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("addLicensedata", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue(@"companyName", companyTextbox.Text.Trim());
            sqlCmd.Parameters.AddWithValue(@"softwareName", softwareTextbox.Text.Trim());
            sqlCmd.Parameters.AddWithValue(@"prodID", prodidTextbox.Text.Trim());
            sqlCmd.Parameters.AddWithValue(@"licenseType", cbLicensetype.Text.Trim());
            sqlCmd.Parameters.AddWithValue(@"LicenseNo", licensekeyNum.Text.Trim()); //no of license keys 
            sqlCmd.ExecuteNonQuery();
            //MessageBox.Show("Added to database");
            sqlCon.Close();
            if (cbLicensetype.SelectedItem.ToString() == "Trial")
            {
                sqlCmd.Parameters.AddWithValue(@"TrialDays", tbTrialdays.Text.Trim());
            }
            addtoFKtable();
    private void addtoFKtable()
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");
            Con.Open();
            SqlCommand Cmd = new SqlCommand("addLicensekeys", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue(@"LicenseNo", licensekeyNum.Text.Trim());
            Cmd.Parameters.AddWithValue(@"LicenseKeys", lbHidden.Text.Trim());
            Cmd.Parameters.AddWithValue(@"prodID", prodidTextbox.Text.Trim());
            Cmd.Parameters.AddWithValue(@"companyName", companyTextbox.Text.Trim());
            Cmd.ExecuteNonQuery();
            //MessageBox.Show("Added license to database");
            Con.Close();
        }
