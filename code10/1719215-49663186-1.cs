    public class RawValue
    {
       public RawValue(string key, IEnumerable<IEnumerable<string>> values)
       {
          Key = key;
          Values = values;
       }
       public string Key { get; set; }
       public IEnumerable<IEnumerable<string>> Values { get; set; }
    }
    
    public class NameSpace : Dictionary<string, NameSpace>
    {
    }
