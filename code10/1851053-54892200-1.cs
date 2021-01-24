    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace ConsoleApp15
    {
        class Program
        {
            static void Main(string[] args)
            {
                var connectionString = "Server=.;Database=tempdb;integrated security=true";
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_Test", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
    
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
    
                    
                    da.Fill(dt);
    
                    Console.WriteLine($"SqlClient: { typeof(SqlConnection).Assembly.FullName}");
                    dt.TableName = "sp_test";
                    dt.WriteXmlSchema(Console.Out);
                    Console.WriteLine($"rows {dt.Rows.Count}");
                }
    
                
            }
        }
    }
