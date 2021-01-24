    var files = JObject.Parse(YourJson);
    var recList = files.SelectToken("$..selectedBusinessUnits").ToList();
    foreach (JObject item in recList)
    {
       foreach (JProperty prop in item.Children())
          {
             string key = prop.Name.ToString();
             string value = prop.Value.ToString();
          }
    }
