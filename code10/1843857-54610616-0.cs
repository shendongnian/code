    using (MySqlConnection conn = new MySqlConnection(.....))
    {
        try
        {
            string query = "SELECT name, siteID FROM site";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "site");
            cmbOrderReceiving.DisplayMember = "name";
            cmbOrderReceiving.ValueMember = "siteID";
            cmbOrderReceiving.DataSource = ds.Tables["site"];
        }
    }
