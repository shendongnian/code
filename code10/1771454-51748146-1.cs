    using(var conn = new SqlConnection("connectionString")
    {
        try
        {
            conn.Open();
            using (var sqlCmd = new SqlCommand("sp_rename")
            {
                CommandType = CommandType.StoredProcedure,
                Parameters =
                {
                    new SqlParameter("@old_name", "oldtablename"),
                    new SqlParameter("@new_name", "newtablename")
                },
                Connection = conn
            })
            {
                sqlCmd.ExecuteNonQuery();
            }   
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message.Trim());
        }
        finally
        {
            if(conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
