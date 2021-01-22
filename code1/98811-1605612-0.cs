    using (SmartSqlReader reader = Db.CurrentDb.ExecuteReader(sp))
     {
      while (reader.Read())
      {
       a.blablabla += reader.GetInt32("BLA_BLA_BLA"); 
      }
      reader.Close();
     }
