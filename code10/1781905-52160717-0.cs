    for (int i = dt.Columns.Count - 1; i >= 0; i--)
    {
    	if (dt.AsEnumerable().All(r => string.IsNullOrWhiteSpace(Convert.ToString(r[colMaping.Key]))))
    		dt.Columns.RemoveAt(0);
    }
