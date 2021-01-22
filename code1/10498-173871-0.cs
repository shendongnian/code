    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string query = "SELECT * FROM t where 1=0";
                string connectionString = "initial catalog=test;data source=localhost;Trusted_Connection=Yes";
    
                DataTable tblSchema;
    
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        cnn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.KeyInfo))
                        {
                            tblSchema = rdr.GetSchemaTable();
                        }
                        cnn.Close();
                    }
                }
                int numColumns = tblSchema.Columns.Count;
                foreach (DataRow dr in tblSchema.Rows)
                {
                    Console.WriteLine("{0}: {1}", dr["ColumnName"], dr["DataType"]);
                }
    
                Console.ReadLine();
            }
        }
    }
