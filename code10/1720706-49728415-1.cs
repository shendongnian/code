            var myTable = new DataTable("Table1");
            
            foreach (var item in bla)
            {
                if (!myTable.Columns.Contains(item))
                {
                    myTable.Columns.Add(new DataColumn(item, typeof(string)));
                }
            }
            var row = myTable.NewRow();
            row["MyColumnName"] = "FieldValue";
            myTable.Rows.Add(row);
  
