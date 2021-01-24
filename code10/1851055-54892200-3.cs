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
                    SqlCommand sqlComm = new SqlCommand("USP_DYNAMIC_PIVOT", conn);
                    sqlComm.Parameters.Add(new SqlParameter("@STATIC_COLUMN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "Date" });
                    sqlComm.Parameters.Add(new SqlParameter("@PIVOT_COLUMN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "category" });
                    sqlComm.Parameters.Add(new SqlParameter("@VALUE_COLUMN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "amount" });
                    sqlComm.Parameters.Add(new SqlParameter("@TABLE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "dbo.temp" });
                    sqlComm.Parameters.Add(new SqlParameter("@AGGREGATE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "sum" });
    
                    sqlComm.CommandType = CommandType.StoredProcedure;
    
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
    
                    da.Fill(dt);
                
                    Console.WriteLine($"SqlClient: { typeof(SqlConnection).Assembly.FullName}");
                    dt.TableName = "sp_test";
                    dt.WriteXmlSchema(Console.Out);
                    Console.WriteLine();
                    Console.WriteLine($"rows {dt.Rows.Count}");
                }
    
    
            }
        }
    }
