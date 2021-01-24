    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SqlBulkCopyTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var src = "server=localhost;database=tempdb;integrated security=true";
                var dest = src;
    
                var sql = "select top (1000*1000*10) m.* from sys.messages m, sys.messages m2";
    
                var destTable = "dest";
    
                using (var con = new SqlConnection(dest))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = $"drop table if exists {destTable}; with q as ({sql}) select * into {destTable} from q where 1=2";
                    cmd.ExecuteNonQuery();
                }
    
                Copy(src, dest, sql, destTable);
                Console.WriteLine("Complete.  Hit any key to exit.");
                Console.ReadKey();
            }
    
            static void Copy(string sourceConnectionString, string destinationConnectionString, string query, string destinationTable)
            {
                using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
                {
                    sourceConnection.Open();
    
                    SqlCommand commandSourceData = new SqlCommand(query, sourceConnection);
    
                    var reader = commandSourceData.ExecuteReader();
    
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnectionString))
                    {
                        bulkCopy.BulkCopyTimeout = 60 * 10;
                        bulkCopy.DestinationTableName = destinationTable;
                        bulkCopy.NotifyAfter = 10000;
                        bulkCopy.SqlRowsCopied += (s, a) =>
                        {
                            var mem = GC.GetTotalMemory(false);
                            Console.WriteLine($"{a.RowsCopied:N0} rows copied.  Memory {mem:N0}");
                        };
                         // Write from the source to the destination.
                         bulkCopy.WriteToServer(reader);
             
                    }
                }
            }
    
     
        }
    }
