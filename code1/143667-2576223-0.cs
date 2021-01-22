    using (var cn = new SqlConnection("your connection string"))
    {
        using (var cmd = new SqlCommand("getbug", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bugID", bugID);
    
            //etc...
        }
    }
