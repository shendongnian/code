          using System;
       using Npgsql;         // Npgsql .NET Data Provider for PostgreSQL
     
       class Sample
       {
         static void Main(string[] args)
         {
            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" + 
                                    "Password=pwd;Database=postgres;");
            conn.Open();
     
            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand("select city from cities", conn);
     
            // Execute a query
            NpgsqlDataReader dr = cmd.ExecuteReader();
     
            // Read all rows and output the first column in each row
            while (dr.Read())
              Console.Write("{0}\n", dr[0]);
     
           // Close connection
           conn.Close();
         }
       }
