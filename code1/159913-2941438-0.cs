    try
    {
        conn.Open();
        object result = cmd.ExecuteNonQuery();
        string test = (string)cmd.Parameters["@RETURN_VALUE"].Value;
        conn.Close();
    }
    catch (Exception ex)
    {
       ....
    }
