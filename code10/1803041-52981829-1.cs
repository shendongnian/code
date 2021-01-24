    var datalist = new List<IDictionary<string, string>>();
    for (var i = 0; i < dataTable.Rows.Count; ++i)
    {
      var data = new Dictionary<string, string>();
        foreach (var name in arrColumnNames)
        { 
          data[name] = Convert.ToString(dataTable.Rows[i][name]);
        }
        datalist.Add(data);
    }
