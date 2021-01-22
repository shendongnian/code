    SqlActions SqlActions = new SqlActions();
    SqlCeCommand SqlCmd = new SqlCeCommand("SET IDENTITY_INSERT People ON", SqlActions.Connection());
    try
    {
        SqlCmd.ExecuteNonQuery();
        string query = "INSERT INTO People SET (ID, Nome) VALUES (@ID, @Nome)";
        SqlCmd.CommandText = query;
        SqlCmd.Parameters.AddWithValue("@ID", 15);
        SqlCmd.Parameters.AddWithValue("@Nome", "Maria");
        SqlCmd.ExecuteNonQuery();
    }
    catch (SqlCeException Error)
    {
        Console.WriteLine(Error.ToString());
    }
