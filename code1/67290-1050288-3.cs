    var csv = @"Name, Age
    Ronnie, 30
    Mark, 40
    Ace, 50";
    
    TextReader reader = new StringReader(csv);
    var table = new DataTable();
    using(var it = reader.ReadCsvWithHeader().GetEnumerator())
    {
    
        if (!it.MoveNext()) return;
      	foreach (var k in it.Current.Keys)
   	    	table.Columns.Add(k);
    
        do
        {
        	var row = table.NewRow();
        	foreach (var k in it.Current.Keys)
    	    	row[k] = it.Current[k];
    	
        	table.Rows.Add(row);
    	
        } while (it.MoveNext());
    }
