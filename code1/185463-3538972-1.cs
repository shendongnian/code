    using (SQLiteTransaction trans = DataAccess.ConnectionManager.BeginTransaction()) 
    {  
      foreach (var week in weekList)
      {
        foreach (var day in week.Days)
        { 
          foreach (var period in day.Periods)
          {
            using (SQLiteCommand com = new SQLiteCommand(...))
            {   
              com.Parameters.Add(new SQLiteParameter(...));
              com.Parameters.Add(new SQLiteParameter(...));
              com.Parameters.Add(new SQLiteParameter(...));
              com.CommandText = "Insert into ...";
              com.ExecuteNonQuery();
            }
          }
        }
      }
      trans.Commit();                
    } 
