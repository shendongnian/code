    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    
    namespace InventoryManagementSystem
    {
        class DBConnect : IDisposable
        {
    
           
            private static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Private\InventoryManagementSystem\InventoryManagementSystem\InventoryDB.mdf;Integrated Security=True";
            public SqlConnection con = new SqlConnection(connectionString);
    
            public DBConnect()
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Database connected");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Database Connection Failed");
                    throw new Exception();
                }
            }
    
            public void Dispose()
            {
                con.Close();
            }
        }
    }
