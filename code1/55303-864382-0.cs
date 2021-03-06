    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    
    
    namespace AccessTableSchema
    {
        class Program
        {
            public static DbConnection GetConnection()
            {
                return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\Test.mdb");
            }
    
            static void Main(string[] args)
            {
                using (DbConnection conn = GetConnection())
                {
                    conn.Open();
    
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = "select * from Test where 1 = 0";
                    command.CommandType = CommandType.Text;
    
                    DbDataReader reader = command.ExecuteReader();
                    DataTable schemaTable = reader.GetSchemaTable();
    
                    conn.Close();
    
                    PrintSchemaPlain(schemaTable);
                    Console.WriteLine(new string('-', 80));
                    PrintSchemaAsXml(schemaTable);
                }
    
                Console.Read();
            }
    
            private static void PrintSchemaPlain(DataTable schemaTable)
            {
                foreach (DataRow row in schemaTable.Rows)
                {
                    Console.WriteLine("{0}, {1}, {2}",
                        row.Field<string>("ColumnName"),
                        row.Field<Type>("DataType"),
                        row.Field<int>("ColumnSize"));
                }
            }
    
            private static void PrintSchemaAsXml(DataTable schemaTable)
            {
                StringWriter stringWriter = new StringWriter();
                schemaTable.WriteXml(stringWriter);
                Console.WriteLine(stringWriter.ToString());
            }
        }
    }
