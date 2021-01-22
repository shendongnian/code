    using (SqlConnection cn1 = new SqlConnection("connection string here")) //inbound data
    using (SqlCommand cmd1 = new SqlCommand("SELECT uniqueid, State FROM myList", cn1)) 
    using (SqlConnection cn2 = new SqlConnection("connection string here"))
    using (SqlCommand cmd2 = new SqlCommand("UPDATE myList SET State= @State WHERE uniqueID= @ID", cn2))
    {
        SqlParameter StateParam = cmd2.Parameters.Add("@State", SqlDbType.VarChar, 50);
        SqlParameter IDParam = cmd2.Parameters.Add("@ID", SqlDbType.Int);
        cn1.Open();
        cn2.Open();
        using (SqlDataReader rdr = cmd1.ExecuteReader())
        {
            while (rdr.Read())
            {
                StateParam  = rdr["State"].ToString().ToUpper();
                IDParam = rdr["uniqueID"];
                cmd2.ExecuteNonReader();
            }
        }
    }
