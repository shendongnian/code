You're inspecting the wrong part of the object. What you should be inspecting is dataTable => rows => Results View => [0] => ItemArray. See the below (more expanded version) of your code to better demonstrate.
    static void Main(string[] args)
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(int));
                dataTable.Columns.Add("name", typeof(string));
    
                var rowCount = dataTable.Rows.Count;
                Console.WriteLine(rowCount);
    
                var dataRow = dataTable.NewRow();
                dataRow["id"] = "1";
                dataRow["name"] = "Jesse";
                dataTable.Rows.Add(dataRow);
    
                var rowCountAfterAdding = dataTable.Rows.Count;
                Console.WriteLine(rowCountAfterAdding);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var ia in row.ItemArray)
                    {
                        Console.WriteLine(ia);
                    }
                }
            }
