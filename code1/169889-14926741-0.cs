    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
        ";Mode=ReadWrite;Extended Properties=\"Excel 8.0;HDR=NO\"";
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (OleDbCommand cmd = new OleDbCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = "CREATE TABLE [MySheet] (a string)";  // Doesn't matter what the field is called
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE [MySheet$] SET F1 = \"\"";
            cmd.ExecuteNonQuery();
        }
        conn.Close();
    }
