    // Verify that username is unique
    using (SqlCommand cmd = new SqlCommand("UPDATE tblSiteSettings SET isActive = 0", cn))
    {
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
    using (SqlCommand cmd = new SqlCommand("INSERT INTO tblSiteSettings (allowProductRatings, allowComments, siteName, settingDate, isActive) VALUES (@allowRatings, @allowcomments, @siteName, getDate(), 1)", cn))
    {
        cmd.Parameters.Add("@allowRatings", SqlDbType.Bit).Value = 1;
        cmd.Parameters.Add("@allowcomments", SqlDbType.Bit).Value = 1;
        cmd.Parameters.Add("@siteName", SqlDbType.VarChar, 128).Value = "lol";
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
