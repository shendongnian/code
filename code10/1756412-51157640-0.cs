    var files = JArray.Parse(YourJSON);
    foreach (JArray item in files.Children())
     {
          foreach (JObject obj in item.Children())
            {
               foreach (JProperty prop in obj.Children())
                {
                   string key = prop.Name.ToString();
                   string value = prop.Value.ToString();
                }
                    
            }
     }
