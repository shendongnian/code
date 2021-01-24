    DataTable table = new DataTable("SomeData");
    table.Columns.Add("Point", typeof(int));
    table.Rows.Add(5);
    table.Rows.Add(7);
    table.Rows.Add(52);
    table.Rows.Add(2);
    table.Rows.Add(1);
    table.Rows.Add(4);
    table.Rows.Add(9);
    
    var row = table.AsEnumerable().Select((r, i) => new { Row = r, Index = i }).Where(x => (int)x.Row["Point"] == 52).FirstOrDefault();
    int rowNumber = 0;
    if (row != null)
    	rowNumber = row.Index + 1;
