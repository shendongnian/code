    var files = JObject.Parse(YourJSONHere);
    var recList = files.SelectTokens("$").ToList();
    foreach (JObject item in recList)
    {
       foreach (JProperty prop in item.Children())
         {
                string key = prop.Name.ToString();
                string value = prop.Value.ToString();
                // or do whatever 
         }
    }
