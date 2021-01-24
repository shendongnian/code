    var datalist = new List<IDictionary<string, string>>();
    
    var data = new Dictionary<string, string>();
    for (var i = 0; i < dataTable.Rows.Count; ++i)
    {
    	foreach (var name in arrColumnNames)
    	{
    		data[name] = Convert.ToString(dataTable.Rows[i][name]);
    	}
        datalist.Add(data);
    	data = new Dictionary<string, string>(data);
    }
