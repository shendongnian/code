        DataTable tbl =  view.ToTable();
        DataColumn[] pk = new DataColumn[table2.PrimaryKey.Length];
        var names = table2.PrimaryKey.Select(column => column.ColumnName).ToArray();
        for (int i = 0; i < names.Length; i++)
        {
            //tbl.PrimaryKey[i] = tbl.Columns[names[i]];
             pk[i] = tbl.Columns[names[i]]; 
        }
        tbl.PrimaryKey = pk;
