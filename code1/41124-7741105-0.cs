    FileInfo file = new FileInfo(@"E:\someSqlScript.sql");
    string script = file.OpenText().ReadToEnd();
      // split script on GO command
      IEnumerable<string> commandStrings = Regex.Split( script, "^\\s*GO\\s*$", RegexOptions.Multiline );
     
      Connection.Open();
      foreach( string commandString in commandStrings )
      {
        if( commandString.Trim() != "" )
        {
          new SqlCommand( commandString, Connection ).ExecuteNonQuery();
        }
      }     
      Connection.Close();
