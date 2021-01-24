    private int InsertData()
        {
            int AffectedRecords = 0;
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.cnnString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Participant (LastName, FirstName, Country, Gender, IACMember, Rank, SponsorId VALUES (@LastName, @FirstName, @Country, @Gender, @IACMember, @Rank, @SponsorId)", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@Country", cboCountry.SelectedItem);
                    //Your Remaining Fields
                    AffectedRecords = cmd.ExecuteNonQuery();
                }
            }
            return AffectedRecords;
        }
