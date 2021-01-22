           public bool CreateScript(string oldDatabase, string newDatabase)
       {
           SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=" + newDatabase + ";User Id=sa;Password=sa;");
           try
           {
               Server sv = new Server();
               Database db = sv.Databases[oldDatabase];
               Database newDatbase = new Database(sv, newDatabase);
               newDatbase.Create(); 
               ScriptingOptions options = new ScriptingOptions();
               StringBuilder sb = new StringBuilder();
               options.ScriptData = true;
               options.ScriptDrops = false;
               options.ScriptSchema = true;
               options.EnforceScriptingOptions = true;
               options.Indexes = true;
               options.IncludeHeaders = true;
               options.WithDependencies = true;
               TableCollection tables = db.Tables;
               conn.Open();
               foreach (Table mytable in tables)
               {
                   foreach (string line in db.Tables[mytable.Name].EnumScript(options))
                   {
                       sb.Append(line + "\r\n");
                   }
               }
               string[] splitter = new string[] { "\r\nGO\r\n" };
               string[] commandTexts = sb.ToString().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
               foreach (string command in commandTexts)
               {
                   SqlCommand comm = new SqlCommand(command, conn);
                   comm.ExecuteNonQuery();
               }
               return true;
           }
           catch (Exception e)
           {
               System.Diagnostics.Debug.WriteLine("PROGRAM FAILED: " + e.Message);
               return false;
           }
           finally
           {
               conn.Close();
           }
       }
