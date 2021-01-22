    SqlActions SqlActions = new SqlActions();
    string query = "SET IDENTITY_INSERT People ON;INSERT INTO People SET (ID, Nome) VALUES (@ID, @Nome)";
    SqlCeCommand SqlCeCommand SqlInsert = new SqlCeCommand(query, SqlActions.Connection());
    SqlInsert.Parameters.AddWithValue("@ID", 15);
    SqlInsert.Parameters.AddWithValue("@Nome", "Maria");
    try
    {
        SqlInsert.ExecuteNonQuery();
    }
    catch (SqlCeException Error)
    {
        Console.WriteLine(Error.ToString());
    }
