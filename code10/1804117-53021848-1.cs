    try
    {
        using (SqlConnection con = new SqlConnection(connStr))
        {
            con.Open();
        }
        return true;
    }
    catch
    {
        return false;
    }
