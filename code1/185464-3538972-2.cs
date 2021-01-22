    using (SQLiteTransaction trans = DataAccess.ConnectionManager.BeginTransaction())
    {  
      using (SQLiteCommand com = new SQLiteCommand(DataAccess.ConnectionManager))
      {   
        com.CommandText = "Insert into ...";
        SQLiteParameter p1 = com.Parameters.Add(new SQLiteParameter(...));
        SQLiteParameter p2 = com.Parameters.Add(new SQLiteParameter(...));
        SQLiteParameter p3 = com.Parameters.Add(new SQLiteParameter(...));
        foreach (var week in weekList)
        {
          p1.Value = week;
          foreach (var day in week.Days)
          { 
            p2.Value = day;
            foreach (var period in day.Periods)
            {
              p3.Value = period;               
              com.ExecuteNonQuery();
            }
          }
        }
      }
      trans.Commit();                
    }
