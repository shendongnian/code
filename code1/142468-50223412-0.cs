    class CSVParser
     {
       public static DataTable ParseCSV(string path)
       {
         if (!File.Exists(path))
        return null;
    string full = Path.GetFullPath(path);
      string file = Path.GetFileName(full);
      string dir = Path.GetDirectoryName(full);
      //create the "database" connection string 
      string connString = "Provider=Microsoft.Jet.OLEDB.4.0;"
        + "Data Source=\"" + dir + "\\\";"
        + "Extended Properties=\"text;HDR=No;FMT=Delimited\"";
      //create the database query
      string query = "SELECT * FROM " + file;
      //create a DataTable to hold the query results
      DataTable dTable = new DataTable();
      //create an OleDbDataAdapter to execute the query
      OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connString);
      try
      {
        //fill the DataTable
        dAdapter.Fill(dTable);
      }
      catch (InvalidOperationException /*e*/)
      { }
      dAdapter.Dispose();
      return dTable;
       }
     }
    }
