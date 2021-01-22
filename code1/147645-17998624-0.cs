    SqlConnection tConn = new SqlConnection("ConnectionString");
     
    SqlCommand tCommand = new SqlCommand();
    tCommand.Connection = tConn;
    tCommand.CommandText = "UPDATE players SET name = @name, score = @score, active = @active WHERE jerseyNum = @jerseyNum";
     
    tCommand.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar).Value = "Smith, Steve");
    tCommand.Parameters.Add(new SqlParameter("@score", System.Data.SqlDbType.Int).Value = "42");
    tCommand.Parameters.Add(new SqlParameter("@active", System.Data.SqlDbType.Bit).Value = true);
    tCommand.Parameters.Add(new SqlParameter("@jerseyNum", System.Data.SqlDbType.Int).Value = "99");
     
    tCommand.ExecuteNonQuery();
