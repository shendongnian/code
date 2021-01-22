    using System;
    using System.Data;
    using System.Data.OleDb;
    
    class Sample
    {
      public static void Main() 
      {
        OleDbConnection nwindConn = new OleDbConnection("Provider=SQLOLEDB;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=northwind");
    
        OleDbCommand catCMD = nwindConn.CreateCommand();
        catCMD.CommandText = "SELECT CategoryID, CategoryName FROM Categories";
    
        nwindConn.Open();
    
        OleDbDataReader myReader = catCMD.ExecuteReader();
    
        while (myReader.Read())
        {
          Console.WriteLine("\t{0}\t{1}", myReader.GetInt32(0), myReader.GetString(1));
        }
    
        myReader.Close();
        nwindConn.Close();
      }
    }
