    DataTable dt = new DataTable();
    dt.Columns.Add("Column1", typeof(int));
    dt.Columns.Add("Column2", typeof(int));
    dt.Columns.Add("Column3", typeof(int));
    dt.Columns.Add("Column4", typeof(string));
    dt.Columns.Add("Column5", typeof(string));
    // Fill your data table here
    using (var con = new SqlConnection("ConnectionString"))
    {
        using(var cmd = new SqlCommand("stp_UpsertMyTable", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MyTable", SqlDbType.Structured).Value = dt;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
