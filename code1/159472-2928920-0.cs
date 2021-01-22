    public static DataTable GetData() 
    { 
      try
      {
        SQLiteConnection cnn = new SQLiteConnection("Data Source=c:\\test.db"); 
        SQLiteCommand cmd = new SQLiteCommand("SELECT count(Message) AS Occurances, Message FROM evtlog GROUP BY Message ORDER BY Occurances DESC LIMIT 25", cnn); 
        cnn.Open(); 
        SQLiteDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); 
        DataTable dt = new DataTable(); 
        dt.Load(dr); 
        return dt; 
      }
      catch (Exception ex)
      {
        throw new Exception("Error in GetData()", ex);
      }
    } 
