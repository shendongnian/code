    using (SqlConnection conn = new SqlConnection("MySqlConnectionString"))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from tblPreference"); // you will also have to limit this selection to only rows for this user.
        cmd.Connection = conn;
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                if(dr.GetInt32(dr.GetOrdinal("ShowPreference"))==1) //not sure if this is a bit or int field
                {
                    grid1.Columns.Add(new BoundField(){ 
                        HeaderText = dr.GetString(dr.GetOrdinal("Alias")),
                        DataField = dr.GetString(dr.GetOrdinal("Preference"))
                    });
                }
                
            }
        }
    }
