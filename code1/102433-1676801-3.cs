    using (var cn = new SqlConnection("..."))
    using (var cmd = new SqlCommand("..."))
    {
        cn.Open();
        using(var rdr = cmd.ExecuteReader())
        {
            while(rdr.Read())
            {
                //...
            }
        }
    }
       
