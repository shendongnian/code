    try
    {
        SqlConnection sql = new SqlConnection(@"Network Library=DBMSSOCN;Data Source=YourServer,1433;Initial Catalog=YourDB;Integrated Security=SSPI;");
        sql.Open();
        SqlCommand cmd = sql.CreateCommand();
        cmd.CommandText = "DECLARE @i int WHILE EXISTS (SELECT 1 from sysobjects) BEGIN SELECT @i = 1 END";
        cmd.ExecuteNonQuery(); // This line will timeout.
        cmd.Dispose();
        sql.Close();
    }
    catch (SqlException ex)
    {
        if (ex.Number == -2) {
            Console.WriteLine ("Timeout occurred");
        }
    }
