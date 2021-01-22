    using (DataTable dt = new DataTable())
    {
        da.Fill(dt);
        if (dt.Rows.Count > 0 && !DBNull.Value.Equals(dt.Rows[0]["punish"]))
        {
            MessageBox.Show("punish is not null");
        }
    }
