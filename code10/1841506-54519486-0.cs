    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            var constr = "Server=tcp:xxxxxx.database.windows.net,1433;Initial Catalog=xxxxxx;User ID=xxxxxx;Password=xxxxxx";
    
    
            using (var con = new SqlConnection(constr))
            {
                con.Open();
                
                var cmd = con.CreateCommand();
                cmd.CommandText = "create table #test(id int, data varbinary(max))";
                cmd.ExecuteNonQuery();
    
                var bc = new SqlBulkCopy(con);
                bc.DestinationTableName = "#test";
                bc.BulkCopyTimeout = 0;
    
                var dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("data", typeof(byte[]));
                var buf = Enumerable.Range(1, 1000 * 1000).Select(i => (byte)(i % 256)).ToArray();
                dt.BeginLoadData();
                for (int i = 0; i < 1000*1000*10; i++)
                {
                    var r = dt.NewRow();
                    r[0] = 1;
                    r[1] = buf;
                    dt.Rows.Add(r);
                }
                dt.EndLoadData();
    
                foreach (DataColumn col in dt.Columns)
                {
                    bc.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }
    
                bc.NotifyAfter = 100;
                bc.SqlRowsCopied += (s, a) =>
                {
                    Console.WriteLine($"{a.RowsCopied} rows copied");
                };
                
    
                Console.WriteLine($"Starting {DateTime.Now}");
                bc.WriteToServer(dt);
                Console.WriteLine($"Finished {DateTime.Now}");
    
            }
            Console.WriteLine("done");
        }
    
    
    }
