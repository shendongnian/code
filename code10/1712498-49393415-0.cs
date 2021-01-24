    using System;
    using System.Data.SqlClient;   // System.Data.dll 
    //using System.Data;           // For:  SqlDbType , ParameterDirection
    
    namespace csharp_db_test
    {
       class Program
       {
          static void Main(string[] args)
          {
             try
             {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "your_server.database.windows.net";
                cb.UserID = "your_user";
                cb.Password = "your_password";
                cb.InitialCatalog = "your_database";
    
                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                   connection.Open();
    
                   Submit_Tsql_NonQuery(connection, "2 - Create-Tables",
                      Build_2_Tsql_CreateTables());
    
                   Submit_Tsql_NonQuery(connection, "3 - Inserts",
                      Build_3_Tsql_Inserts());
    
                   Submit_Tsql_NonQuery(connection, "4 - Update-Join",
                      Build_4_Tsql_UpdateJoin(),
                      "@csharpParmDepartmentName", "Accounting");
    
                   Submit_Tsql_NonQuery(connection, "5 - Delete-Join",
                      Build_5_Tsql_DeleteJoin(),
                      "@csharpParmDepartmentName", "Legal");
    
                   Submit_6_Tsql_SelectEmployees(connection);
                }
             }
             catch (SqlException e)
             {
                Console.WriteLine(e.ToString());
             }
             Console.WriteLine("View the report output here, then press any key to end the program...");
             Console.ReadKey();
          }
