       using (sqlite2 = new SQLiteConnection("Data Source=ModuleUserDB.db"))
      {
        sqlite2.Open();  //You must open the connection first
        sqlite2.ChangePassword("password here"); 
        sqlite2..Close
      }
