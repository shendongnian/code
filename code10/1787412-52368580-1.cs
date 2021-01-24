    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    
    using Newtonsoft.Json;
    
    namespace ConsoleApp1 {
        class Program {
            static void Main(string[] args) {
                var dataTable = new DataTable("test");
                dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
                dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
    
                var row1 = dataTable.NewRow();
                row1["ID"] = 1;
                row1["Name"] = "John Smith";
                dataTable.Rows.Add(row1);
    
                var row2 = dataTable.NewRow();
                row2["ID"] = 2;
                row2["Name"] = "Mary Williams";
                dataTable.Rows.Add(row2);
    
                Dictionary<string, object> result = new Dictionary<string, object> {
                    ["Columns"] = dataTable.Columns.Cast<DataColumn>().Select(x => new Dictionary<string, object> { [x.ColumnName] = x.DataType.Name }).ToArray(),
                    ["Rows"] = dataTable.Rows.Cast<DataRow>().Select(x => x.ItemArray).ToArray()
                };
                var json = JsonConvert.SerializeObject(result);
                Console.WriteLine($"json={json}");
            }
    
        }
    }
