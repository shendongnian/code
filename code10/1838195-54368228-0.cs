    private void btnActivate_Click(object sender, EventArgs e)
    {
        bool tempt = false;
        string enteredkey = null; //TODO Probably encrypt here if DB value is encrypted, otherwise whats the point?
        string connectionString = @""; //TODO Set Connection String.
        string licenseKey = null; //TODO: String type?
        string licenseType = null; //TODO: String type?
        using (var con = new SqlConnection(connectionString))
        using (var cmd = con.CreateCommand())
        {
            try
            {
                con.Open();
            }
            catch (SqlException)
            {
                //TODO
            }
            cmd.CommandText = @"
                SELECT LicenseKeys, licenseType
                FROM LicenseKeys
                WHERE LicenseKeys = @LicenseKeys
            ";
            cmd.Parameters.AddWithValue("@LicenseKeys", enteredkey);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        licenseKey = reader.GetString(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        licenseType = reader.GetString(1);
                    }
                }
                else
                {
                    //TODO
                }
            }
        }
        tempt = !string.IsNullOrEmpty(licenseType);
        if (tempt)
        {
            MessageBox.Show(String.Format($"valid license type {licenseType}"));
            //TODO other stuff?
        }
        else
        {
            MessageBox.Show("invalid"); // TODO `enter code here`
            //TODO other stuff?
        }
    }
