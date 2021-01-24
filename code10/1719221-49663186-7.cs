    private static IEnumerable<RawValue> GetRawValues(RawValue value)
    {
       return value.Values.Where(x => x.Any())
                   .GroupBy(x => x.FirstOrDefault())
                   .Select(x => new RawValue(x.Key, x.Select(y => y.Skip(1))));
    }
    
    private static NameSpace GroupNameSpaces(IEnumerable<RawValue> groups)
    {
       var result = new NameSpace();
    
       foreach (var group in groups)
          result.Add(group.Key, GroupNameSpaces(GetRawValues(group)));
    
       return result;
    
    }
