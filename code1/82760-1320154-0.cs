    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class Sample
    {
      public static void Main() 
      {
        SqlConnection nwindConn = new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=northwind");
    
        SqlCommand catCMD = nwindConn.CreateCommand();
        catCMD.CommandText = "SELECT CategoryID, CategoryName FROM Categories";
    
        nwindConn.Open();
    
        SqlDataReader myReader = catCMD.ExecuteReader();
    
        while (myReader.Read())
        {
          Console.WriteLine("\t{0}\t{1}", myReader.GetInt32(0), myReader.GetString(1));
        }
    
        myReader.Close();
        nwindConn.Close();
      }
    }
