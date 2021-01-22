    string[] ColumnsToBeDeleted = { "col1", "col2", "col3", "col4" };
    foreach (string ColName in ColumnsToBeDeleted)
    {
    	if (dt.Columns.Contains(ColName))
    	    dt.Columns.Remove(ColName);
    }
