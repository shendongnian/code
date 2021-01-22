    SqlConnection conn = null;
    SqlCommand cmd = null;
    try
    {
        conn = new SqlConnection(Settings.Default.qlsdat_extensionsConnectionString);
        cmd = new SqlCommand(reportDataSource, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = year;
        cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = start;
        cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = end;
        cmd.Connection.Open();
        DataSet dset = new DataSet();
        new SqlDataAdapter(cmd).Fill(dset);
        this.gridDataSource.DataSource = dset.Tables[0];
    }
    catch (RelevantException ex)
    {
        // ...handling...
    }
    finally
    {
        if (cmd != null)
        {
            try
            {
                cmd.Dispose();
            }
            catch { }
            cmd = null;
        }
        if (conn != null)
        {
            try
            {
                conn.Dispose();
            }
            catch { }
            conn = null;
        }
    }
    // And note that `cmd` and `conn` are still in scope here, even though they're useless
