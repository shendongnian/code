    try
    {
       Con.Open();
       Cmd = new SqlCommand(insert_query, Con);
       Cmd.ExecuteNonQuery();
    }
    finally
    {
        Con.Close();
    }
