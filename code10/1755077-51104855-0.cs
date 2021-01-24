     var files = JArray.Parse(YourJSON);
     var recList = files.SelectTokens("$").ToList();
     foreach (JObject item in recList.Children())
      {
        foreach (JProperty prop in item.Children())
          {
             string key = prop.Name.ToString();
             string value = prop.Value.ToString();
            // and add these to an array
          }
      }
