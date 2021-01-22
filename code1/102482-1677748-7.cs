	public string DoSomething(IList<ITableDataSource> objects)
	{
	  var result = new 
	  {
	    sEcho = 1,
	    iTotalRecords = 1,
	    iTotalDisplayRecords = 1,
	    aaData = new List<IList<string>>()
	  };
	  foreach (ITableDataSource ds in objects)
	    result.aaData.Add(ds.GetTableData());
		
	  return ToJson(result);
	}
    
