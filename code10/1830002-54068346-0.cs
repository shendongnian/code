    using(SqlConnection con = new SqlConnection("..."))
    {
        con.Open();
        using(SqlCommand cmd = new SqlCommand("...", con))
        {
            using(SqlDataReader dr = cmd.ExecuteReader())
            {
                while(dr.Read())
                    // Do the things
            }
        }
        // Do not need close since connection will be disposed
    }
