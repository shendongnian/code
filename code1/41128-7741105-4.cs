      string script = File.ReadAllText(@"E:\someSqlScript.sql");
      // split script on GO command
      IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", 
                               RegexOptions.Multiline | RegexOptions.IgnoreCase);
     
      Connection.Open();
      foreach (string commandString in commandStrings)
      {
        if (commandString.Trim() != "")
        {
          new SqlCommand(commandString, Connection).ExecuteNonQuery();
          // Don't forget to Dispose() the SqlCommand !! - or using(SqlCommand ...)
        }
      }     
      Connection.Close();
