            var myTable = new DataTable("Table1");
            
            foreach (var item in bla)
            {
                myTable.Columns.Add(new DataColumn("MyColumnName", typeof(string)));
            }
            var row = myTable.NewRow();
            row["MyColumnName"] = "FieldValue";
            myTable.Rows.Add(row);
  
