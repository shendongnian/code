    var groups = list.Select(x => x.Split('.'))
                      .GroupBy(x => x.FirstOrDefault())
                      .Select(x => new RawValue(x.Key, x.Select(y => y.Skip(1))));
    
    var settings = new JsonSerializerSettings
       {
          NullValueHandling = NullValueHandling.Ignore
       };
    
    var result = GroupNameSpaces(groups);
    
    var json = JsonConvert.SerializeObject(result, Formatting.Indented, settings);
    
    Console.WriteLine(json);
