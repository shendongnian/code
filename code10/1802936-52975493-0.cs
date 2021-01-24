    var datalist = new List<IDictionary<string, string>>();
    string[] arrNames = ConfigurationManager.AppSettings["NameKey"].Split(',');
    for (var i = 0; i < dt.Rows.Count; ++i)
    {
        var data = new Dictionary<string, string>();
        foreach (var name in arrNames)
        {
            data[name] = Convert.ToString(dt.Rows[i][name]);
        }
                
        datalist.Add(data);
    }
