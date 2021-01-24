    DataSet ds = new DataSet ();
    using (var conn = new SqlConnection (cs))
    {
        using (var cmd1 = new SqlCommand ("asp_GetTrainingDetail", conn))
        {
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add (
                new SqlParameter ("@id", System.Data.SqlDbType.BigInt) 
                {                    //  ^^^^  chooose one here  ^^^^
                    Value = id 
                });
            using (var da = new SqlDataAdapter (cmd1))
            {
                da.Fill (ds);
            }
        }
    }
