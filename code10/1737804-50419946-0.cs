    public static bool CreateSQLDatabaseTable()
    {
        var connString = "Server=localhost\\SQLEXPRESS;Integrated Security = SSPI; database = MyDB";
        string cmdText = "SELECT count(*) as Exist from INFORMATION_SCHEMA.TABLES where table_name =@Product";
        using (var sqlConnection = new SqlConnection(connString))
        {
            using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
            {
                sqlCmd.Parameters.Add("@Product", System.Data.SqlDbType.NVarChar).Value = "Product";
                sqlConnection.Open();
                sqlCmd.ExecuteScalar();
                if ((int)sqlCmd.ExecuteScalar() != 1)
                {
                    using (SqlCommand command = new SqlCommand("CREATE TABLE Product (Id INT, UserId TEXT, CreationDate TEXT, Name TEXT)", sqlConnection))
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public static void Main()
    {
        try
        {
            bool wasCreated = CreateSQLDatabaseTable();
        }
        catch (SqlException ex)
        {
            // Handle the SQL Exception as you wish
            Console.WriteLine(ex.ToString());
        }
    }
