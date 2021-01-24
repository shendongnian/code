    string query = "INSERT INTO table(CampaignId, CookieId, Url) VALUES (@campaignid, @cookieid, @url)";
    using (SqlConnection c = new SqlConnection(connectstring)) {
        c.Open();
        SqlCommand cmd = new SqlCommand(query, c);
        cmd.Parameters.Add(new SqlParameter("@campaignid", SqlDbType.Int, 0)); //use appropriate type/size here
        cmd.Parameters.Add(new SqlParameter("@cookieid", SqlDbType.Int, 0)); //use appropriate type/size here
        cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.NVarChar, 500)); //use appropriate type/size here
        cmd.Prepare();
        foreach (var item in container.items) {
            cmd.Parameters[0].value = item.CampaignId;
            cmd.Parameters[1].value = item.VisitorExternalId;
            cmd.Parameters[2].value = item.url;
            cmd.ExecuteNonQuery();
        }
    }
