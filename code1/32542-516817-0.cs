    public int Insert(Person person)
    {
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    SqlCommand dCmd = new SqlCommand("InsertData", conn);
    dCmd.CommandType = CommandType.StoredProcedure;
    try
    {
    dCmd.Parameters.AddWithValue("@firstName", person.FirstName);
    dCmd.Parameters.AddWithValue("@lastName", person.LastName);
    dCmd.Parameters.AddWithValue("@age", person.Age);
    return dCmd.ExecuteNonQuery();
    }
    catch
    {
    throw;
    }
    finally
    {
    dCmd.Dispose();
    conn.Close();
    conn.Dispose();
    }
    }
