    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    // ...
    var payload = JObject.Parse(rawJson);
    var dataArray = payload["data"] as JArray;
    var columns = dataArray.Properties().Select(prop => prop.Name).ToList();
    var rows = (
        from obj as JObject in dataArray
        select columns.Select(col => obj[col]).ToList()
    ).ToList();
        
