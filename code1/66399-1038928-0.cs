                DataTable table = new DataTable();
                table.Columns.Add("a", typeof(int));
    
                DataRow r = table.NewRow();
                r[0] = 10;
                table.Rows.Add(r);
    
                r = table.NewRow();
                r[0] = 12;
                table.Rows.InsertAt(r, 0);
