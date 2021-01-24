    var pivotTable = myList.ToPivotTable(
    		  item => item.Date,
    		  item => item.Name,
    		  items => items.Any() ? items.Max(x => x.Hour) : 0);
    
    foreach (DataRow rw in pivotTable.Rows)
    {
    	Console.WriteLine(string.Format("{0}   {1}   {2}", rw[0], rw[1], rw[2]));
    }
    
