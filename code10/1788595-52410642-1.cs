    public class GetJson
    {
      private readonly ConfigModel _ConfigModel;
      public GetJson(ConfigModel configModel)
      {
        _ConfigModel = configModel;
      }
      public ConfigModel RetrieveValues()
      {
        return _ConfigModel;          
      }
    }
