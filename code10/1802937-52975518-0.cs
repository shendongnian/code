    var datalist = new List<IDictionary<string, string>>();
    string[] arrNames = Convert.ToString(ConfigurationManager.AppSettings["NameKey"]).Split(',');
    if(arrNames.Length == 3)
    {
    for (var i = 0; i < dt.Rows.Count; ++i)
    {
      var data = new Dictionary<string, string>()
      {
          { arrNames[0],     Convert.ToString(dt.Rows[i][arrNames[0]]) },
          { arrNames[1], Convert.ToString(dt.Rows[i][arrNames[1]]) },
          { arrNames[2],   Convert.ToString(dt.Rows[i][arrNames[2]]) }
      };
    
       datalist.Add(data);
     }
    }
