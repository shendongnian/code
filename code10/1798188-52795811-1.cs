    JObject obj = JObject.Parse(json);
    RootObject root = new RootObject
    {
        Office = (string)obj["Office"],
        SearchItemList = 
            obj.Properties()
               .Where(p => p.Name.StartsWith("SearchItemList["))
               .Select(p =>
               {
                   var parts = p.Name.Split(new string[] { "[", "]." }, 3, StringSplitOptions.None);
                   return new
                   {
                       Index = int.Parse(parts[1]),
                       Property = new JProperty(parts[2], p.Value)
                   };
               })
               .GroupBy(a => a.Index)
               .OrderBy(g => g.Key)
               .Select(g => new JObject(g.Select(a => a.Property)).ToObject<SearchItem>())
               .ToList()
    };
