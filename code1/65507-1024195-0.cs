    var iCounter = 0;
    foreach (Employee item in employees)
    {
    
       if (iCounter == 0)
      {
        cmd.BeginTransaction;
      }
      string sql = @"INSERT INTO Mytable (id, name, salary) 
        values ('@id', '@name', '@salary')";
      // replace @par with values
      cmd.CommandText = sql; // cmd is IDbCommand
      cmd.ExecuteNonQuery();
      iCounter ++;
      if(iCounter >= 500)
      {
         cmd.CommitTransaction;
         iCounter = 0;
      }
    }
    
    if(iCounter > 0)
       cmd.CommitTransaction;
