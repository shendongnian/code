    SqlCommand cmd = new SqlCommand("select username from usermst where userid=2", conn);
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    adp.Fill(dt);
    string getusername = "";
    // assuming userid is unique
    if (dt.Rows.Count > 0)
        getusername = dt.Rows[0]["username"].ToString();
