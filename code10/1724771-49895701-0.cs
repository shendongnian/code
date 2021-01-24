      //DONE: wrap IDisposable into using
      using(SqlConnection conn = new SqlConnection(@"MyConnectionString")) {
        conn.Open();
        //DONE: Make sql readable
        string sql = 
          $@"CREATE TABLE [{tableName}] (
               IdPy      INT IDENTITY(1,1),
               Question  NVARCHAR (MAX)     NOT NULL, 
               IsChecked BIT                NOT NULL,
               --DONE: Constraint key word added 
               CONSTRAINT [CONSTRAINTPK_{tableName}] PRIMARY KEY(Id) 
             )";
        //DONE: wrap IDisposable into using
        using (qlCommand cmd = new SqlCommand(sql, conn)) {
          cmd.ExecuteNonQuery();
        }
      } 
