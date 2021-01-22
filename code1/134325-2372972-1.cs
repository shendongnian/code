    using(SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        string cmdInsert = "insert into carsdescription(description) value (@description)";
        using(sqlCommand cmd = new SqlCommand(cmdInsert, conn))
        {
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();
        }
        string selectStmt = "select nameOfCar from dbo.Cars where idCar = @idCar";
        using(sqlCommand cmd2 = new SqlCommand(selectStmt, conn))
        {
            cmd2.Parameters.AddWithValue("@idCar", idCar);
            
            string resultValue = cmd2.ExecuteScalar().ToString();
        }
        conn.Close();
    }
