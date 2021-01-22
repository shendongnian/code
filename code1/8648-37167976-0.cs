    try
    {
    	ds.EnforceConstraints = true;
    }
    catch (ConstraintException ex)
    {
    	string details = string.Join("",
    		ds.Tables.Cast<DataTable>()
    			.Where(t => t.HasErrors)
    			.SelectMany(t => t.GetErrors())
    			.Take(50)
    			.Select(r => "\n - " + r.Table.TableName + "[" + string.Join(", ", r.Table.PrimaryKey.Select(c => r[c])) + "]: " + r.RowError));
    	throw new ConstraintException(ex.Message + details);
    }
