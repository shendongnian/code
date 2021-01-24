    dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(YourJsonString);
    foreach (var prop in obj)
    {
       if (prop is Newtonsoft.Json.Linq.JObject)
       {
          // Handle JObject
       }
    
       if (prop is Newtonsoft.Json.Linq.JProperty)
       {
          // Handle JProperty
       }
    }
