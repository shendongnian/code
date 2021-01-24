    con.Open();
    using (var cmd = new SqlCommand("SELECT PhotoId from Accounts where Username like @user", con)) {
        cmd.Parameters.AddWithValue("@user", ecid);
        using (var reader = await cmd.ExecuteReaderAsync()) {
            if (!reader.HasRows || ! reader.Read()) {
                MessageBox.Show("User not found");
            } else {
                DataPid = cmd.GetYOURDATATYPE(0).ToString();
                //....
            }
            
        }
    }
    con.Close();
