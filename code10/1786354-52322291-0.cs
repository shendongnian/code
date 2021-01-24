    using System.Data.SqlClient;
    namespace MyConnection
    {
    class Connection
    {
      public static SqlConnection GetConnection()
      {
            string connectionString = "Data Source=WhateverYourdataSource;Initial Catalog=EDI;Persist Security Info=True;User ID=YourID;Password=Password.is;Integrated Security=False;MultipleActiveResultSets=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
    }
