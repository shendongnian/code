      string connectionString;
      string fileName = "aminescm.sdf";
      string password = “aminescm”;
 
      if (File.Exists(fileName))
      {
        File.Delete(fileName);
      }
 
      connectionString = string.Format(
        "DataSource=\"{0}\"; Password='{1}'", fileName, password);
      SqlCeEngine en = new SqlCeEngine(connectionString);
      en.CreateDatabase();
