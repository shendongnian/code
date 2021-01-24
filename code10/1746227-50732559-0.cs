    var affectedRows = -1;
    var cs = ""; // your connection string
    try 
    {
        var cn = new SqlConnection(cs);
        cn.Open();
        using (var cmd = cn.CreateCommand())
        {
            cmd.CommandText = your_query; // TBD;
            var prm = new SqlParameter("prm", value); // as needed
            cmd.Parameters.Add(prm); // as needed
            affectedRows = cmd.ExecuteNonQuery();
        }
        /// and if you have nothing else to do.
        cn.Close();
        cn.Dispose();
        cn = null;
    }
    catch(Exception ex)
    {
        System.Diagnostics.Trace.TraceError("Whoops! {0}", ex);
        // error handling
    }
    
