    using System;
    using System.Data;
    using System.Data.Odbc;
    
    class Sample
    {
      public static void Main() 
      {
        OdbcConnection nwindConn = new OdbcConnection("Driver={SQL Server};Server=localhost;" +
                                                      "Trusted_Connection=yes;Database=northwind");
    
        OdbcCommand catCMD = new OdbcCommand("SELECT CategoryID, CategoryName FROM Categories", nwindConn);
    
        nwindConn.Open();
    
        OdbcDataReader myReader = catCMD.ExecuteReader();
    
        while (myReader.Read())
        {
          Console.WriteLine("\t{0}\t{1}", myReader.GetInt32(0), myReader.GetString(1));
        }
    
        myReader.Close();
        nwindConn.Close();
      }
    }
