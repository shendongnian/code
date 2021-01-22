    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    
    class MainClass
    {
      static void Main(string[] args)
      {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=C:\\Northwind.mdb";
    
        OleDbConnection conn = new OleDbConnection(connectionString);
    
        string sql = "SELECT * FROM Orders";
                                              
        OleDbCommand cmd = new OleDbCommand(sql, conn);
    
        conn.Open();
    
        OleDbDataReader reader;
        reader = cmd.ExecuteReader();
    
        while (reader.Read()) 
        {
          Console.Write(reader.GetString(0).ToString() + " ," );
          Console.Write(reader.GetString(1).ToString() + " ," );
          Console.WriteLine("");
        }
    
        reader.Close();
        conn.Close();
      }
    }
