     private void saveProcToAFile()
     {
         StreamWriter log;
    
         if (!File.Exists("procedureToBeLoaded.sql"))
         {
             log = new StreamWriter("procedureToBeLoaded.sql");
         }
         else
         {        
             log = new StreamWriter(File.Create("procedureToBeLoaded.sql"));
         }           
    
         SqlConnection conn = new SqlConnection(conString);
         SqlDataAdapter da = new SqlDataAdapter();
         SqlCommand cmd = conn.CreateCommand();
         cmd.CommandText = string.Format("EXEC sp_helptext '{0}'", "procedure_name"); //Step 1.
         da.SelectCommand = cmd;
         DataSet ds = new DataSet();
    
         conn.Open();
         da.Fill(ds); //Step 2.
         conn.Close();
    
         foreach (DataRow dr in ds.Tables[0].Rows)
         {
             log.WriteLine(dr[0]); //Step 3.
         }
                
         log.Close();          
      }   
