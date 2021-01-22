    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class ExecuteScalar
    {
      public static void Main()
      {
        SqlConnection mySqlConnection =new SqlConnection("server=(local)\\SQLEXPRESS;database=MyDatabase;Integrated Security=SSPI;");
        SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
        mySqlCommand.CommandText ="SELECT COUNT(*) FROM Employee";
        mySqlConnection.Open();
    
        int returnValue = (int) mySqlCommand.ExecuteScalar();
        Console.WriteLine("mySqlCommand.ExecuteScalar() = " + returnValue);
    
        mySqlConnection.Close();
      }
    }
