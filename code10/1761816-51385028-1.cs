    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT COUNT(*) from dbo.tUser where pin = @pin", sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@pin", Int32.Parse(pin.Text.Trim()));
            
            var count = (int)sqlCmd.ExecuteScalar();
            if (count > 0)
            {
                // Pin exists logic
            }
            if (count < 1)
            {
                // Pin doesn't exist logic
            }
        }
    }
