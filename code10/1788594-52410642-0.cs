    public class ParseJson
    {
      public GetJson Serializer()
      {
        var json = File.ReadAllText(@"config.json");
        ConfigModel objConfig = 
           JsonConvert.DeserializeObject<ConfigModel(json);
        return new GetJson(objConfig);
      }
