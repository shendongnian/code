    DataSet ds = new DataSet ();
    using (var conn = new SqlConnection (cs))
    {
        using (var cmd1 = new SqlCommand ("asp_GetTrainingDetail", conn))
        {
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@id", System.Data.SqlDbType.BigInt).Value = id;
            using (var da = new SqlDataAdapter (cmd1))
            {
                da.Fill (ds);
            }
        }
    }
