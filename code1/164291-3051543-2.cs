    Dictionary<string, string> map = new Dictionary<string, string>
    {
      { "matchtype", null },
      { "matches", null },
      { "ballsbowled", null }
    };
    foreach (XmlElement elm in stats.SelectNodes("*"))
    {
       if (map.ContainsKey(elm.Name))
       {
          map[elm.Name] = elm.InnerText;
       }
    }
